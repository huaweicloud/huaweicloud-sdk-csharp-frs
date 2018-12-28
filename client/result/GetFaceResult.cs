using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class GetFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_set_id")]
        public string faceSetId;

        [JsonProperty(PropertyName = "Face_set_name")]
        public string faceSetName;

        [JsonProperty(PropertyName = "faces")]
        public List<Face> faces;
    }
}
