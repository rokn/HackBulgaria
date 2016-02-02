use HackCompany;

CREATE TABLE OrderProducts
(
	OrderId int FOREIGN KEY REFERENCES [Order](Id) NOT NULL,
	ProductId int FOREIGN KEY REFERENCES [Product](Id) NOT NULL,
	Quantity int NOT NULL,
	PRIMARY KEY (OrderId, ProductId)
);