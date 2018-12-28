using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class BlurClassifyResult : JsonObject
    {
        [JsonProperty(PropertyName = "isClarity")]
        public bool isClarity;
    }
}
