use HackCompany;

SELECT TOP 1 d.Id, d.Name FROM Employee e1
JOIN Department d
ON e1.DepartmentId = d.Id
GROUP BY d.Id, d.Name
ORDER BY count(d.Id) DESC;