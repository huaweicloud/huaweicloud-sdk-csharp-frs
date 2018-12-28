using System.Collections.Generic;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class VideoResult : JsonObject
    {
        [JsonProperty(PropertyName = "alive")]
        public bool alive;

        [JsonProperty(PropertyName = "actions")]
        public List<Action> actions;

        [JsonProperty(PropertyName = "picture")]
        public string picture;
    }
}
