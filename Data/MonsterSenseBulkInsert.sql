/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual MonserSense Table
*/
CREATE TABLE #TempMonsterSense (
    SenseRange NVARCHAR(MAX),
    MonsterId INT,
    SenseId INT
);

BULK INSERT #TempMonsterSense
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\monstersensedatafile.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO MonsterSense (SenseRange, MonsterId, SenseId)
SELECT SenseRange, MonsterId, SenseId
FROM #TempMonsterSense;

DROP TABLE #TempMonsterSense;

SELECT * FROM MonsterSense;
DELETE FROM MonsterSense;
DBCC CHECKIDENT ('MonsterSense, RESEED, 0');



