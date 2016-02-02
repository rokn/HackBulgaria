use HackCompany;

GO
	CREATE PROCEDURE SwapBigBoss
	(
		@employeeId int
	)
	AS
	DECLARE @employeeManager int;
	DECLARE @employeeDepartment int;
	DECLARE @bossId int;

	SELECT @employeeManager = ManagerId,
		   @employeeDepartment = DepartmentId from Employee
	WHERE Id = @employeeId;

	SELECT @bossId = Id
	FROM Employee
	Where ManagerId IS NULL;

	Update Employee
	SET ManagerId = @employeeManager, DepartmentId = @employeeDepartment
	WHERE ManagerId IS NULL;

	UPDATE Employee
	SET ManagerId = NULL, DepartmentId = NULL
	WHERE Id = @employeeId;

	Update Employee
	SET ManagerId = @employeeId
	WHERE ManagerId = @bossId;
GO