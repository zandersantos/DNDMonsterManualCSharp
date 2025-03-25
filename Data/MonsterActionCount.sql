/*
A Query that displays the top 10 most used Actions.
*/

SELECT TOP 10 
    a.Name AS ActionName, 
    COUNT(ma.MonsterId) AS MonsterCount
FROM MonsterAction ma
JOIN Action a ON ma.ActionId = a.Id
GROUP BY a.Name
ORDER BY MonsterCount DESC