using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class FieldType : JsonObject
    {
        [JsonProperty(PropertyName = "type")]
        public string type;
    }
}
