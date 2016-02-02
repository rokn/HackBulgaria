use HackCompany;

CREATE TABLE Customer
(
	[Id] int PRIMARY KEY IDENTITY(1,1),	
	[Name] nvarchar(50) NOT NULL,
	[Email] nvarchar(50) NULL,
	[Address] nvarchar(200) NOT NULL,
	[Discount] smallint NULL
);