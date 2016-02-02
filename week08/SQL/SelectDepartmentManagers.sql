use HackCompany;

SELECT * FROM Employee e1
WHERE (
		SELECT [ManagerId] 
		FROM Employee e2 
		WHERE e2.id = e1.ManagerId) IS NULL 
AND e1.ManagerId IS NOT NULL;