using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class GetAllFaceSetsResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_sets_info")]
        public List<FaceSet> faceSetsInfo;
    }
}
