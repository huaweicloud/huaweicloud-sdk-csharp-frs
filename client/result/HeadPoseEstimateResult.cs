using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class HeadPoseEstimateResult : JsonObject
    {
        [JsonProperty(PropertyName = "yaw")]
        public double yaw;

        [JsonProperty(PropertyName = "roll")]
        public double roll;

        [JsonProperty(PropertyName = "pitch")]
        public double pitch;
    }
}
