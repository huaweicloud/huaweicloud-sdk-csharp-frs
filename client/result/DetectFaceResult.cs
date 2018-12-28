using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class DetectFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "faces")]
        public List<DetectFace> faces;
    }
}
