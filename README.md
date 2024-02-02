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
