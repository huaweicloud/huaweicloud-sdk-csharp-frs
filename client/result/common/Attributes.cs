using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Attributes : JsonObject
    {
        [JsonProperty(PropertyName = "headpose", NullValueHandling = NullValueHandling.Ignore)]
        public HeadPose headPose;

        [JsonProperty(PropertyName = "gender", NullValueHandling = NullValueHandling.Ignore)]
        public string gender;

        [JsonProperty(PropertyName = "age", NullValueHandling = NullValueHandling.Ignore)]
        public int age;

        [JsonProperty(PropertyName = "dress", NullValueHandling = NullValueHandling.Ignore)]
        public Dress dress;

        [JsonProperty(PropertyName = "smile", NullValueHandling = NullValueHandling.Ignore)]
        public string smile;
    }
}
