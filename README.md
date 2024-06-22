# Requirement

 Design and implement a database that can store the following objects: 
o Grid - That stores the list of TSO/ISOs. You can use Grid1, Grid2 and
Grid3 as the entries. 
o Grid Regions - Has a many-to-one relation with Grid. Use Region1,
Region2 and Region3 as the entries for each Grid. 
o Grid Nodes - Has a many-to-one relation with Grid Regions. Use
Node1, Node2 and Node3 as the entries for each Grid Region. 
o Design a table (Measures) that can hold hourly timeseries values of
Grid Nodes. 
 This table should support storing the evolution of time series
data. Definition of evolution in this context (example) - At 9 AM,
the Grid Node can have a value of 100 for timestamp 11 PM of
the following day. The same Grid Node at 10 AM can have a value
of 99 for the same datetime 11 PM of the following day. 
 Implement the Measures schema on a SQL database (PostgreSQL is an open-
source option, but you are free to use any database of your choice). 
 Write a script to insert records for 1 week for all 3 Nodes including the
hourly evolution. 
 Write an API that will accept a start datetime and end datetime. The API
should return the latest value for each timestamp in the date range. 
 Write another API that will accept a start datetime, end datetime and
collected datetime. The API should return the value corresponding to the
collected datetime for each timestamp in the date range.

# GridSolution
Sample Application based on Scenario given.

## Technology  and tools Stack:

1.	C#
2.	.Net Core 6.0
3.	EfCore 6.0.10
4.	Visual Studio 2022 Professional
5.	PostMan
6.	InMemeoryDb (accessible in Visual studio View -> sql server Object Explorer)
7.	MsTest
8.	.net core sdk 6.0.3.02



##Api Endpoints

### JSON request body:

{
    "StartDate" : "2024-02-2T15:00:00.000Z",
    "EndDate" : "2024-02-10 19:00:00.000Z",
    "CollectedDate" : "2024-02-03 07:00:00.000Z",
    /*use either NodeName or Node Id 
    --if both are provided with  Node Id .0 will take precedence
    --if both not provided it will only query based on start and end date
    */
    "NodeName": null,
    "NodeId": 0
} 

 
1. http://localhost:7240/api/grid/latest
2.  http://localhost:7240/api/grid/collected
