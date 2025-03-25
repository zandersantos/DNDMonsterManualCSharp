/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual Monster Table
*/
CREATE TABLE #TempMonsters (
    Name NVARCHAR(MAX),
    ArmourClass INT,
    HitPoints NVARCHAR(MAX),
    HitDice NVARCHAR(MAX),
    ImageUrl NVARCHAR(MAX)
);

BULK INSERT #TempMonsters
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\monstersdatafile.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO Monster (Name, ArmourClass, HitPoints, HitDice, ImageUrl)
SELECT Name, ArmourClass, HitPoints, HitDice, ImageUrl
FROM #TempMonsters;

DROP TABLE #TempMonsters;

SELECT * FROM Monster;
DELETE FROM Monster;
DBCC CHECKIDENT ('Monster', RESEED, 0);