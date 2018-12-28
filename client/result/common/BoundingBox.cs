using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class BoundingBox : JsonObject
    {
        [JsonProperty(PropertyName = "width")]
        public int width;

        [JsonProperty(PropertyName = "height")]
        public int height;

        [JsonProperty(PropertyName = "top_left_x")]
        public int topLeftX;

        [JsonProperty(PropertyName = "top_left_y")]
        public int topLeftY;
    }
}
