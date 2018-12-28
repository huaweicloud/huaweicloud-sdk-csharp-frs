using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Point : JsonObject
    {
        [JsonProperty(PropertyName = "x")]
        public float x;

        [JsonProperty(PropertyName = "y")]
        public float y;
    }
}
