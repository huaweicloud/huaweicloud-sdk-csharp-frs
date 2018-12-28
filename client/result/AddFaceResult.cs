using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class AddFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_set_id")]
        public string faceSetId;

        [JsonProperty(PropertyName = "face_set_name")]
        public string faceSetName;

        [JsonProperty(PropertyName = "faces")]
        public List<Face> faces;
    }
}
