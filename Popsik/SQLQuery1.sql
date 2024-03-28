SELECT * FROM Departments
SELECT p.* FROM Persons p
INNER JOIN Departments d ON p.DepartmentId = d.Id
WHERE d.Id = @Id