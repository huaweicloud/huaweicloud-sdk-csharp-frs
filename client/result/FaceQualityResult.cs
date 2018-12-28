using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class FaceQualityResult : JsonObject
    {
        [JsonProperty(PropertyName = "blur")]
        public BlurClassifyResult blur;

        [JsonProperty(PropertyName = "pose")]
        public HeadPoseEstimateResult pose;
    }
}
