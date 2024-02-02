using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GridFunctions.ApiEndpoints
{
    public class CollectedValueHttpGetFunction
    {
        private readonly ICollectedValueFunctionHandler _collectedValueFunctionHandler;
        ILogger<CollectedValueHttpGetFunction> _logger;
        public CollectedValueHttpGetFunction(ICollectedValueFunctionHandler collectedValueFunctionHandler, ILogger<CollectedValueHttpGetFunction> logger)
        {
            _collectedValueFunctionHandler = collectedValueFunctionHandler;
            _logger = logger;
        }

        [FunctionName(nameof(CollectedValueHttpGetFunction))]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Measures" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]

        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "grid/collected")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                NodeMeasurementQueryDto nodeMeasurementQueryDto = JsonConvert.DeserializeObject<NodeMeasurementQueryDto>(requestBody);

                List<Measure> measureList = await _collectedValueFunctionHandler.HandleRequest(nodeMeasurementQueryDto);

                return await Task.FromResult(new NativeJsonResult(measureList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
