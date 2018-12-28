using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Dress : JsonObject
    {
        [JsonProperty(PropertyName = "glass")]
        public string glass;

        [JsonProperty(PropertyName = "hat")]
        public string hat;
    }
}
