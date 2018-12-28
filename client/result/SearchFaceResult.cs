using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class SearchFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "faces")]
        public List<ComplexFace> faces;
    }
}
