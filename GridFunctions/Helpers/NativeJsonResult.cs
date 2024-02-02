using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GridFunctions.Helpers
{
    public class NativeJsonResult : ContentResult
    {
        private const string ContentTypeApplicationJson = "application/json";
        public NativeJsonResult(object value, JsonSerializerOptions options = null)
        {
            JsonSerializerOptions option = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //to avoid circular issue while serializing the data
                ReferenceHandler = ReferenceHandler.Preserve
            };

            options ??= option;

            ContentType = ContentTypeApplicationJson;
            Content = JsonSerializer.Serialize(value, options);
        }
    }
}
