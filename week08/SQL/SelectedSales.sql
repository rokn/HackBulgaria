use HackCompany;

SELECT * FROM Employee e1
JOIN Department d
ON e1.DepartmentId = d.Id
WHERE d.Name = 'Sales'
ORDER BY e1.Name ASC;