drop table if exists dbo.EmployeeJob;
drop table if exists dbo.Job;
drop table if exists dbo.Employee;

create table dbo.Job
(Id int identity(1, 1) primary key
, Name nvarchar(200) not null
, Budget decimal(14, 2) not null default 0
, Comment nvarchar(4000) null
);

create table dbo.Employee 
(Id int identity(1, 1) primary key
, Name nvarchar(200) not null
, Salary decimal(14, 2) not null default 0
, Skill nvarchar(200) not null
, Comment nvarchar(4000) null
);

create table dbo.EmployeeJob(
Id int identity(1, 1) primary key,
JobId int not null,
EmployeeId int not null,
unique (JobId, EmployeeId),
foreign key (JobId) references dbo.Job(Id) ON DELETE CASCADE,
foreign key (EmployeeId) references dbo.Employee(Id) ON DELETE CASCADE
);

insert dbo.Job(Name, Budget, Comment) values ('Plant A Refit', $1000000, 'Big plant refit, 24 month project');
insert dbo.Job(Name, Budget, Comment) values ('Factory B Shutdown', $5000000, 'Shutdown and modernisation project, expected duration 3 years');
insert dbo.Job(Name, Budget, Comment) values ('Retail Space 3 Renovation', $665000, 'Renovate and update retail clothing outlet, expected duration 4 months');

insert dbo.Employee(Name, Salary, Skill, Comment) values ('Bill', 80000, 'Carpenter', 'Started 2015, good on big projects');
insert dbo.Employee(Name, Salary, Skill, Comment) values ('Frank', 85000, 'Project Manager', 'Started 2022, retail project manager experience');
insert dbo.Employee(Name, Salary, Skill, Comment) values ('Sally', 105000, 'Quantity Engineer', 'Started 2020, project materials costing, refit specialist');
insert dbo.Employee(Name, Salary, Skill, Comment) values ('Ted', 95000, 'Accountant', 'Started 2019, project budget management and cost review expert');
insert dbo.Employee(name, salary, skill, comment) values ('Jenny', 92000, 'Electrician', 'Started 2018, good with very high voltage');

insert dbo.EmployeeJob(JobId, EmployeeId) values (1, 1);
insert dbo.EmployeeJob(JobId, EmployeeId) values (1, 2);
insert dbo.EmployeeJob(JobId, EmployeeId) values (1, 3);

insert dbo.EmployeeJob(JobId, EmployeeId) values (2, 3);
insert dbo.EmployeeJob(JobId, EmployeeId) values (2, 4);
insert dbo.EmployeeJob(JobId, EmployeeId) values (2, 5);

insert dbo.EmployeeJob(JobId, EmployeeId) values (3, 1);
insert dbo.EmployeeJob(JobId, EmployeeId) values (3, 2);
insert dbo.EmployeeJob(JobId, EmployeeId) values (3, 4);
insert dbo.EmployeeJob(JobId, EmployeeId) values (3, 5);

drop table Product;

create table Product
(
	Id int identity(1, 1) primary key,
	Name nvarchar(200) not null,
	Price decimal(4, 2) not null default 0,
);

insert Product (Name, Price) values ('T-Shirt', 56.33);
insert Product (Name, Price) values ('Jacket', 75.18);
insert Product (Name, Price) values ('Shoes', 88.88);