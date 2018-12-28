using System.Collections.Generic;
using FrsSDK.common;

namespace FrsSDK.client.param
{
    public class SearchReturnFields
    {
        private readonly List<string> prop;

        public SearchReturnFields()
        {
            prop = new List<string>();
        }

        public void AddReturnField(string key)
        {
            prop.Add(key);
        }

        public string GetString()
        {
            return HttpUtils.ObjToString(prop);
        }
    }
}
