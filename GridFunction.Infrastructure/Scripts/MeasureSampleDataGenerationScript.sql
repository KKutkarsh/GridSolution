-- Date from which we are starting 
DECLARE @StartDate DATETIME = CAST(GETDATE() as Date);
set @StartDate = DATEADD(DAY,-1, @StartDate);

-- when the data is inserted/collected
Declare @CurrentDate DATETIME = GETDATE();

--end date
DECLARE @EndDate DATETIME = DATEADD(DAY, 7, @StartDate);

delete from Measures;

WHILE @StartDate <= @EndDate
BEGIN

   -- node id wise insert approach is used to have variation in measurement value,
   -- using in will make too much repeatative data
    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId = 1;
    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId = 2;
    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId = 3;

    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId = 6;
    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId = 8;

    --to Ensure that the measured grid value have enough repeated value for testing
    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId in (4,5);

    INSERT INTO Measures (InsertedAt,CollectedTime, Measurement, GridNodeId)
    SELECT @CurrentDate, @StartDate, ROUND(RAND() * 100, 0), GridNodeId 
    FROM GridNodes where GridNodeId in (7,9);
    -- *********--

    SET @StartDate = DATEADD(HOUR, 1, @StartDate);
    Set @CurrentDate = DATEADD(HOUR, 1, @CurrentDate);
END;