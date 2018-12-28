using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class DeleteFaceResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_number")]
        public int faceNumber;

        [JsonProperty(PropertyName = "face_set_id")]
        public string faceSetId;

        [JsonProperty(PropertyName = "face_set_name")]
        public string faceSetName;
    }
}
