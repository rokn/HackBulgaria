use HackCompany;

SELECT DISTINCT
	d.Id,
	d.Name 
FROM Employee e
JOIN Department d
ON e.DepartmentId = d.Id
WHERE YEAR(e.DateOfBirth) > 1900