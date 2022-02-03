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