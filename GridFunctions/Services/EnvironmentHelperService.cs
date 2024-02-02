using GridFunctions.Services.Interfaces;
using System;

namespace GridFunctions.Services
{
    /// <summary>
    /// Good Idea to implement environment helper because it can be extended for usage like
    /// 1. Cache environment variables
    /// 2. Generic read Endpoint for azureVault and configuration variables
    /// 3. Can be use to distinguish between different environments (dev/staging/sandbox/prod)
    /// </summary>
    internal class EnvironmentHelperService : IEnvironmentHelperService
    {
        public string GetEnvironmentVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        }
    }
}
