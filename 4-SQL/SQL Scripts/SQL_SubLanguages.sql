---Data Definition Language---
--Creating/altering table structures in our DB

--Create statement to create poke table
create table Pokemon(
	pokeName varchar(50),
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int
)

--Alter statement to change existing tables
alter table Pokemon
--add alive bit
drop column alive

--Truncate statement

--Drop statement
drop table Pokemon

--- Data Manipulation Language ---
--Adding/removing/manipulating the data inside of table structures

--Insert statement
insert into Pokemon
values('Pikachu', 1, 55,12 ,123),
	('Bulbasaur', 10,23,23,523)
	
--Select statement
select pokeName, pokeLevel from Pokemon

select * from Pokemon

--Update statement
update Pokemon set pokeHealth = 50
where pokeName = 'Bulbasaur'

update Pokemon set pokeHealth = 1
where pokeName = 'Pikachu'

--Delete statement
delete from Pokemon 
where pokeName = 'Pikachu'

--- Data Query Language ---

select pokeName, pokeLevel from Pokemon

select * from Pokemon

select pokeName, pokeLevel from Pokemon
where pokeName = 'Pikachu'

--Aliasing, basically renaming a column name
select pokeName as Name, pokeLevel from Pokemon

------------------Constraints---------------------
-- They are a way for you to limit the data that will come into your table (hence the name "constraints")
-- It is possible to specify more than one constraints

--Type
--Restricts what datatype can be put in a column

--Unique
--Data in this column cannot have replicating values
create table Pokemon(
	pokeName varchar(50) unique,
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int
)
--alter statement to add constraint
alter table Pokemon 
add constraint pokeName_unique unique(pokeName)

--Remove constraint
alter table Pokemon 
drop constraint pokeName_unique

--Not null
--Data in this column cannot be null

create table Pokemon(
	pokeName varchar(50) unique not null,
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int
)

--alter statement to add not null
alter table Pokemon 
alter column pokeName varchar(50) not null

insert into Pokemon 
values ('MissingNo',null,null,null,null)

--Default
--Will provide a default value in case a value was not provided

--Check
--Adds an extra condition on the data
--pokeLevel > 10

--Primary Key
--Data in this column is both unique and not null
--Acts as a unique identifier for the row in a table

--Foreign Key
--Data in this column references another row from a different column
--Used mainly to establish relationships between two tables

--------------Multiplicity---------------
--It is a way to describe the relationships between 2 tables
--We will use primary keys and foreigns keys to establish it

--One to One
--One row in Table A is directly related to one row in Table B and it goes both ways
create table person(
	SSN int primary key,
	personName varchar(50),
	personAge int
)

create table heart(
	heartId int primary key,
	heartSize int,
	healthy bit,
	personSSN int unique foreign key references person(SSN)
)

insert into person 
values (1, 'Brandon', 25)

insert into person 
values (2, 'Terrance', 23)

insert into person 
values (3, 'Vijhan', 23)

insert into heart 
values (2, 100, 1, 2)

select person.personName, h.healthy from person
inner join heart h on person.SSN = h.personSSN
where person.SSN = 1

--One to Many
--One row in Table A is related to multiple rows in Table B
create table finger(
	fingerId int primary key,
	fingerLength int 
)

alter table finger
add personSSN int foreign key references person(SSN)

insert into finger 
values (1, 10, 1),
	(2, 5, 1),
	(3, 3, 1)
	
select * from person p 
inner join finger f on p.SSN = f.personSSN 

--Many to Many
--Many rows in Table A has many rows in Table B
--You must create a join table to create many to many relationship

--Pokemon will have a many to many relationship with ability
Create table Ability(
	abId int primary key,
	abName varchar(50),
	abPP int,
	abPower int,
	abAccuracy int
)

select * from Pokemon p 

--Adding pokeId column in Pokemon with a primary key constraint
alter table Pokemon 
add constraint pokeId_primary primary key(pokeId)

--You must create a join table to establish many to many relationships
create table abilities_pokemons (
	--The two minimum columns in a join table must either references the two tables you want a many to many relationship to have
	abId int foreign key references Ability(abId),
	pokeId int foreign key references Pokemon(pokeId)
)

--Inserting values to Ability table
insert into Ability 
values(1, 'Tackle', 40, 50, 80)
values(2, 'Thunderbolt', 50,100, 70)

--Inserting values in the join table establishes the actual relationship between the rows
insert into abilities_pokemons
values (2, 3) --abId of 2 is Thunderbolt and pokeId of 3 is pikachu so that means pikachu will have thunderbolt
	(1,1), --abId of 1 is Tackle and pokeId of 1 is Bulbasaur so that means bulbasaur will have tackle
	(1, 3) --abId of 1 is Tackle and pokeId of 3 is Pikachu so that manes pikachu will have tackle as well
	
--Creating select join statements of many to many relationship requires at least two inner joins
--Select a starting point (Not the join table itself) and go from there
--In this case, I started with ability and joined the join table and then joined the pokemon table last
select a.abName, p.pokeName from Ability a 
inner join abilities_pokemons ap on a.abId = ap.abId 
inner join Pokemon p on p.pokeId = ap.pokeId 

--------------Normalization---------------
--It is design pattern that reduces/eliminates data redudancy/data duplication
--Must have Referential Integerity and atomic data
	--referential integerity just means that a foreign key will always point to an existing primary key
	--atomic data just means the data in your table is at its smallest form

--0NF - Zero Normal Form
--No normalization

--1NF - First Normal Form
--Everty table must have a primary key
--Must have Atomic data

--2NF - Second Normal Form
--you must be in 1NF
--Remove any partial dependencies
	-- Just don't do composite primary keys

--3NF - Third Normal Form
--You must be in 2NF
--Remove any transitive dependencies
	--Make sure that every column in that table is actually related to the data you are storing
	--Ex: Pokemon table shouldn't have ability name, power point, acurracy but ability table should be created instead

