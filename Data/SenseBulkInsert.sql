/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual Sense Table
*/
CREATE TABLE #TempSense (
    SenseType NVARCHAR(MAX),
);

BULK INSERT #TempSense
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\sensedata.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO Sense (SenseType)
SELECT SenseType
FROM #TempSense;

DROP TABLE #TempSense;

SELECT * FROM Sense;
DELETE FROM Sense;
DBCC CHECKIDENT ('Sense', RESEED, 0);