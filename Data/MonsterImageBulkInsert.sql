/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual Image Table
*/
CREATE TABLE #TempMonsterImage (
   MonsterId INT,
   Url NVARCHAR(MAX)
);

BULK INSERT #TempMonsterImage
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\imagedatafile.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO MonsterImage (MonsterId, Url)
SELECT MonsterId, Url
FROM #TempMonsterImage;

DROP TABLE #TempMonsterImage;

SELECT * FROM MonsterImage;
DELETE FROM MonsterImage;
DBCC CHECKIDENT ('MonsterImage', RESEED, 0);

SELECT Id, MonsterId, Url
FROM MonsterImage;


