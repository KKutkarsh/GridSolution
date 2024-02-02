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
    public class LatestValueHttpGetFunction
    {
        private readonly ILatestValueFunctionHandler _latestValueFunctionHandler;
        private readonly ILogger<LatestValueHttpGetFunction> _logger;
        public LatestValueHttpGetFunction(ILatestValueFunctionHandler latestValueFunctionHandler, ILogger<LatestValueHttpGetFunction> logger)
        {
            _latestValueFunctionHandler = latestValueFunctionHandler;
            _logger = logger;
        }

        [FunctionName(nameof(LatestValueHttpGetFunction))]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Measures" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "grid/latest")] HttpRequest req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                NodeMeasurementQueryDto nodeMeasurementQueryDto = JsonConvert.DeserializeObject<NodeMeasurementQueryDto>(requestBody);

                List<Measure> measureList = await _latestValueFunctionHandler.HandleRequest(nodeMeasurementQueryDto);

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
