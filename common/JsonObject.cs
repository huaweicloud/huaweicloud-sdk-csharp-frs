using System;
namespace FrsSDK.common
{
    public class JsonObject
    {
        public string GetJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
