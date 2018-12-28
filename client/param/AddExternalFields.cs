using System.Collections.Generic;
using FrsSDK.common;

namespace FrsSDK.client.param
{
    public class AddExternalFields
    {
        private readonly Dictionary<string, object> prop;

        public AddExternalFields()
        {
            prop = new Dictionary<string, object>();
        }

        public void AddField(string key, object value)
        {
            prop[key] = value;
        }

        public string GetString()
        {
            return HttpUtils.ObjToString(prop);
        }

    }
}
