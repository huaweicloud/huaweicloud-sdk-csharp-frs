using System.Collections.Generic;
using FrsSDK.common;

namespace FrsSDK.client.param
{
    public class CreateExternalFields
    {
        private readonly Dictionary<string, Dictionary<string, string>> prop;

        public CreateExternalFields()
        {
            prop = new Dictionary<string, Dictionary<string, string>>();
        }

        public void AddField(string fieldName, FieldType fieldType)
        {
            prop[fieldName] = new Dictionary<string, string>
            {
                { "type", fieldType.ToString().ToLower() }
            };
        }

        public string GetString()
        {
            return HttpUtils.ObjToString(prop);
        }
    }
}
