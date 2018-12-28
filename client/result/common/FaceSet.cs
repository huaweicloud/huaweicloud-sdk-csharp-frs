using System.Collections.Generic;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class FaceSet : JsonObject
    {
        [JsonProperty(PropertyName = "face_number", NullValueHandling = NullValueHandling.Ignore)]
        public int faceNumber;

        [JsonProperty(PropertyName = "face_set_id", NullValueHandling = NullValueHandling.Ignore)]
        public string faceSetId;

        [JsonProperty(PropertyName = "face_set_name", NullValueHandling = NullValueHandling.Ignore)]
        public string faceSetName;

        [JsonProperty(PropertyName = "create_date", NullValueHandling = NullValueHandling.Ignore)]
        public string createDate;

        [JsonProperty(PropertyName = "face_set_capacity", NullValueHandling = NullValueHandling.Ignore)]
        public int faceSetCapacity;

        [JsonProperty(PropertyName = "external_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, string>> externalFields;
    }
}
