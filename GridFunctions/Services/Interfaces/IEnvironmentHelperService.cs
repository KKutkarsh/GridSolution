namespace GridFunctions.Services.Interfaces
{
    public interface IEnvironmentHelperService
    {
        //StorageAccount
        const string StorageAccountConnectionString = "AzureWebJobsStorage";

        // Database
        const string SQLServerConnectionString = "SQLServerConnectionString";

        string GetEnvironmentVariable(string key);
    }
}
