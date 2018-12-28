using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class SimpleFace : JsonObject
    {
        [JsonProperty(PropertyName = "bounding_box")]
        public BoundingBox boundingBox;
    }
}
