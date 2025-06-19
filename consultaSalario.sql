SELECT 
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM 
    Pessoa p
JOIN 
    Departamento d ON p.DeptId = d.Id
WHERE 
    p.Salario = (
        SELECT MAX(p2.Salario)
        FROM Pessoa p2
        WHERE p2.DeptId = p.DeptId
    );
