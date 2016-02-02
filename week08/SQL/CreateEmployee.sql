use HackCompany;

CREATE TABLE Employee
(
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar (50) NOT NULL,
	Email nvarchar (50) NULL,
	DateOfBirth date NOT NULL,
	ManagerId int FOREIGN KEY REFERENCES Employee(Id),
	DepartmentId int FOREIGN KEY REFERENCES Department(Id)
);