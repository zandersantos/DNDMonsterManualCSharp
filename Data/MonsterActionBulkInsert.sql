/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual Action Table
*/
CREATE TABLE #TempMonsterAction (
    Description NVARCHAR(MAX),
    DamageType NVARCHAR(MAX),
    DamageDice NVARCHAR(MAX),
    MonsterId INT,
    ActionId INT
);

BULK INSERT #TempMonsterAction
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\monsteractiondatafile.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO MonsterAction (Description, DamageType, DamageDice, MonsterId, ActionId)
SELECT Description, DamageType, DamageDice, MonsterId, ActionId
FROM #TempMonsterAction;

DROP TABLE #TempMonsterAction;

SELECT * FROM MonsterAction;
DELETE FROM MonsterAction;
DBCC CHECKIDENT ('MonsterAction', RESEED, 0);

SELECT Id, Name
FROM Action;

