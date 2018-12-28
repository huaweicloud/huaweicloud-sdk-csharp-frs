using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Action : JsonObject
    {
        [JsonProperty(PropertyName = "action")]
        public int action;

        [JsonProperty(PropertyName = "confidence")]
        public double confidence;
    }
}
