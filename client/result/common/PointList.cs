using System.Collections.Generic;
using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class PointList : JsonObject
    {
        [JsonProperty(PropertyName = "point")]
        public List<Point> point;
    }
}
