﻿using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class GetFaceSetResult : JsonObject
    {
        [JsonProperty(PropertyName = "face_set_info")]
        public FaceSet faceSetInfo;
    }
}
