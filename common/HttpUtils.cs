using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace FrsSDK.common
{
    public static class HttpUtils
    {
        public static T ResponseToObj<T>(HttpWebResponse response)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            String msg = reader.ReadToEnd();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new FrsException((int)response.StatusCode, msg);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(msg);
            }
        }

        public static byte[] ObjToData(object obj)
        {
            String jsonString = JsonConvert.SerializeObject(obj);
            return Encoding.Default.GetBytes(jsonString);
        }

        public static string ObjToString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string LoadFileToBase64(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(data);
        }
    }
}
