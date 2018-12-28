using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Warning : JsonObject
    {
        [JsonProperty(PropertyName = "warningCode")]
        public int warningCode;

        [JsonProperty(PropertyName = "warningMsg")]
        public string warningMsg;
    }
}
