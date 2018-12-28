using System.Collections.Generic;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Face : SimpleFace
    {
        [JsonProperty(PropertyName = "external_image_id")]
        public string externalImageId;

        [JsonProperty(PropertyName = "face_id")]
        public string faceId;

        [JsonProperty(PropertyName = "external_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> externalField;
    }
}
