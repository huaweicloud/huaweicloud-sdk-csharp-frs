using System.Collections.Generic;
using FrsSDK.common;

namespace FrsSDK.client.param
{
    public class SearchSort
    {
        private readonly List<Dictionary<string, string>> prop;

        public SearchSort()
        {
            prop = new List<Dictionary<string, string>>();
        }

        public void AddSortField(string key, SortType sortType)
        {
            Dictionary<string, string> iterm = new Dictionary<string, string>
            {
                { key, sortType.ToString() }
            };
            prop.Add(iterm);
        }

        public string GetString()
        {
            return HttpUtils.ObjToString(prop);
        }

        public List<Dictionary<string, string>> GetValue()
        {
            return prop;
        }
    }
}
