using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class DetectFace : SimpleFace
    {
        [JsonProperty(PropertyName = "attributes", NullValueHandling = NullValueHandling.Ignore)]
        public Attributes attributes;

        [JsonProperty(PropertyName = "landmark", NullValueHandling = NullValueHandling.Ignore)]
        public Landmark landmark;
    }
}
