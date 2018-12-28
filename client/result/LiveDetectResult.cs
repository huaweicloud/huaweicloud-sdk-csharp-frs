using System.Collections.Generic;
using FrsSDK.client.result.common;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result
{
    public class LiveDetectResult : JsonObject
    {
        [JsonProperty(PropertyName = "video-result")]
        public VideoResult videoResult;

        [JsonProperty(PropertyName = "warning-list")]
        public List<Warning> warningList;
    }
}
