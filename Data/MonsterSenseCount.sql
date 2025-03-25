/*
A Query that displays the top 3 most used Senses.
*/

SELECT 
    s.SenseType, 
    COUNT(ms.MonsterId) AS MonsterCount
FROM MonsterSense ms
JOIN Sense s ON ms.SenseId = s.Id
GROUP BY s.SenseType
ORDER BY MonsterCount DESC;