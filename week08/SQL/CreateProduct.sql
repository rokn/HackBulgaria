use HackCompany;

CREATE TABLE Product
(
	Id int PRIMARY KEY IDENTITY(1,1),	
	Name nvarchar(50) NOT NULL,
	Price int NOT NULL,
	Category nchar (3) FOREIGN KEY REFERENCES [Category](Code)
);