using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class CompareFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "similarity")]
        public double similarity;

        [JsonProperty(PropertyName = "image1_face")]
        public SimpleFace image1Face;

        [JsonProperty(PropertyName = "image2_face")]
        public SimpleFace image2Face;
    }
}
