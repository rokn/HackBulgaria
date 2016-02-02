use HackCompany;

UPDATE Employee
SET DateOfBirth = DATEADD(year, 1, DateOfBirth);