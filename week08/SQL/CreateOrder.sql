use HackCompany;

CREATE TABLE [Order]
(
	Id int PRIMARY KEY IDENTITY(1,1),
	CustomerId int FOREIGN KEY REFERENCES Customer(Id),
	TotalPrice int
);