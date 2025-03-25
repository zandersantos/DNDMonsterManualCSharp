/*
Create a Temporary Table to store the CSV Data and then transfer the Data to the Actual Action Table
*/
CREATE TABLE #TempAction (
    Name NVARCHAR(MAX),
);

BULK INSERT #TempAction
FROM 'C:\Users\zainz\Desktop\DNDC#\DungeonsAndDragonsMonsterManualCSharp\DungeonsAndDragonsMonsterManualCSharp\Data\actiondata.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 
);

INSERT INTO Action (Name)
SELECT Name
FROM #TempAction;

DROP TABLE #TempAction;

SELECT * FROM Action;
DELETE FROM Action;
DBCC CHECKIDENT ('Action', RESEED, 0);