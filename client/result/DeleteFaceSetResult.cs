using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class DeleteFaceSetResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_set_name")]
        public string faceSetName;
    }
}
