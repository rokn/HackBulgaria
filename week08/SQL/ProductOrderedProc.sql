use HackCompany;

GO
	CREATE PROCEDURE ProductOrderedTimes
	(
		@productId int
	)
	AS	
		SELECT COUNT(*) FROM OrderProducts 
		WHERE ProductId = @productId;
GO