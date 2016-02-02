use HackCompany;

SELECT DepartmentCount.DepartmentId,
		Department.Name
		FROM 
(SELECT e.DepartmentId
FROM Employee e
GROUP BY e.DepartmentId
HAVING count(e.DepartmentId) >= 3)
AS DepartmentCount, Department
WHERE DepartmentCount.DepartmentId = Department.Id;