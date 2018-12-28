using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class HeadPose : JsonObject
    {
        [JsonProperty(PropertyName = "yaw_angle")]
        public double yawAngle;

        [JsonProperty(PropertyName = "roll_angle")]
        public double rollAngle;

        [JsonProperty(PropertyName = "pitch_angle")]
        public double pitchAngle;
    }
}
