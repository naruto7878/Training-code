---Create statement--
create table Employee(
	empId int identity(1,1) primary key,
	empName varchar(50),
	empSalary smallmoney
);

create table Department(
	depId int identity(1,1) primary key,
	depName varchar(50)
);

--Established relationships--
create table employees_departments(
	empId int foreign key references Employee(empId),
	depId int foreign key references Department(depId)
);

--Inserting values--
insert into Employee 
values('John Doe', 65000),
	('Ollie Abbott', 80000),
	('Emanual Dean', 110000),
	('Ernest Rowe', 55000),
	('Janice Oliver', 65000);

insert into Department
values ('Software Engineer'),
	('Manager');

insert into employees_departments 
values (1,1),
	(2,1),
	(3,2),
	(4,1),
	(5,1);
	
---Aggregation function---
--They are functions that will use all the data of a column to do some sort of manipulation
--You can no longer select columns that aren't aggregated unless you use group by

--Count
--Will count how many rows are in a column
select Count(e.empName) as 'Total Employees' from Employee e 

--Sum
--Will add all the numbers in a column
select Sum(e.empSalary) as 'Summation of all salary' from Employee e 

--Avg
--Will get the average of a column
select avg(e.empSalary) as 'Average Salary' from Employee e 

--Min
--Will get the lowest number in a column
select min(e.empSalary) as 'Lowest Salary' from Employee e 

--Max
--Will get the highest number in a column
select max(e.empSalary) as 'Highest Salary' from Employee e 

--What if I want to show how many employees have 65000 as their salary
select Count(e.empName) as 'Total Employees', e.empSalary from Employee e 
group by e.empSalary 

------ Subquery --------

--I want to take the average of all software engineer's salary
select avg(e.empSalary) as 'Average Software Engineer Salary' from Employee e 
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer';

--I want to select every software engineer that have a higher than average software engineer
--Seems like a very simple question but got really complicated real fast
--With subquery it is just better to run the query first and then copy and paste where required
select e.empName, e.empSalary from Employee e
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer' and e.empSalary > 
(select avg(e.empSalary) from Employee e 
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer');

--- Joins ---
insert into Employee 
values ('Azhya Knox', 60000),
	('Mariya Bukhryakova', 65000);

insert into Department 
values ('Accounting'),
	('HR');

--Left join
--Will show everything from the right table regardless if it found a match or not
select * from Employee e 
left join employees_departments ed on e.empId = ed.empId 
left join Department d on d.depId = ed.depId;

--Right join
--Will show everything from the left table regardless if it found a match or not
select * from Employee e 
right join employees_departments ed on e.empId = ed.empId 
right join Department d on d.depId = ed.depId;

--Full join
--Will show everything from the both tables regardless if it found a match or not
select * from Employee e 
full join employees_departments ed on e.empId = ed.empId 
full join Department d on d.depId = ed.depId;

--- Set operations ---
--Special type of join
--It doesn't care about matching anything unlike a join where you specify where it needs to match
--It will combine two queries together (They need to have the same # of columns and same datatype)

--Union
--It will show only once a duplicate value
select e.empName from Employee e  
union
select d.depName from Department d

--Union all
--It will display all duplicated values
select d.depName from Department d 
union all
select d.depName from Department d

--Except
--It will show only unique values from the right query
--It will not show any duplicated values
select d.depName from Department d
except
select d.depName from Department d

--Intersect
--It will show only duplicated values
select d.depName from Department d
intersect
select d.depName from Department d

--- Stored Procedure ---
-- Almost like a function except it has certain unique things about
-- You can return multiple things unlike C# methods
	-- It can accept input parameters and multiple output parameters
-- It can output multiple datatypes
-- You can have optional parameters

--Add data depending on what was given
alter procedure proc_addData(
	@name varchar(50) = null,
	@salary smallmoney = 10, -- By adding "=" I have made this parameter optional
	@department varchar(50) = null,
	@status bit output -- By adding output keyword, this parameter will return back after executing the procedure
)
AS 
BEGIN
	--Adds data to Employee table if employee name was given
	--When comparing with a null value, you have to use is/is not null
	--When comparing with a normal value, you can use != or <>
	if(@name is not null)
	BEGIN
		insert into Employee 
		values(@name, @salary);
		set @status = 1;
	END
	
	--Adds data to Department table if department name was given
	if(@department is not null)
	begin
		insert into Department 
		values(@department);
		set @status = 1;
	end
	
	--Status fails if both optional parameters was not given
	if(@name is null)
	begin
		if(@department is null)
		begin
			set @status = 0;
		end
	end
END;

declare @currentStatus bit;
declare @moneys smallmoney = 100000.0000;
exec proc_addData @status = @currentStatus output
select @currentStatus;

--- Triggers ---
--They are a special type of stored procedure
--They will run when a certain event happens such as insert, update, delete, or etc.


create trigger trig_employee_added on Employee
After insert
AS
BEGIN
	update Employee 
	set empSalary = empSalary - 1000;
END;

insert into Employee 
values('Terrance', 500);
