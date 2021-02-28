--Table drop sequence
drop table inventories; --dependent on records and inventories
drop table records; --dependent on the enums
drop table genre;
drop table condition;
drop table recFormat;
drop table locations;

--Table Creation DDL
create table genre
(
	id int identity primary key,
	genreName varchar(100)
	check (genreName in ('Rap', 'Rock', 'Pop', 'Classical', 'Kpop', 'Soul', 'Funk'))
	default 'Rap'
);

create table condition
(
	id int identity primary key,
	conditionName varchar(4)
	check (conditionName in ('New', 'Used'))
	default 'New'
);

create table recFormat
(
	id int identity primary key,
	formName varchar(10)
	check (formName in ('Vinyl', 'Cassette', 'CD'))
	default 'Vinyl'
);

create table records
(
	id int identity(1000,1) primary key, 
	recordName nvarchar(100) not null,
	artistName nvarchar(100) not null,
	genre int references genre(id),
	condition int references condition(id),
	recFormat int references recFormat(id),
	price float not null
);
create table locations
(
	id int identity(100,100) primary key,
	locName nvarchar(100) not null
);

create table inventories
(
	idInv int primary key,
	idRec int references records(id),
	idLoc int references locations(id)

);

--Adding seed data
--Filling in enum values
insert into genre (genreName) values
('Rap'), ('Rock'), ('Classical'), ('Kpop'), ('Soul'), ('Funk')
insert into condition (conditionName) values
('New'), ('Used')
insert into recFormat (formName) values
('Vinyl'), ('Cassette'), ('CD')
--Inserting records
insert into records (recordName, artistName, genre, condition, recFormat,price) values
('Telefone', 'Noname', 1, 1, 1, 249.99),
('To Pimp A Butterfly', 'Kendrick Lamar', 1, 1,1,  19.99),
('Scavenger', 'Fleece', 2, 1,2, 9.99),
('Scavenger', 'Fleece', 2,1,3,12.99);



insert into locations (locName) values
('Philadelphia, PA'), ('New York City, NY')

insert into inventories (idInv, idRec, idLoc) values
(1,1000,100), (2,1001,100), (3,1002,200),(4,1003,100),(5,1002,100)

--Check data
select * from records
select * from locations
select * from inventories