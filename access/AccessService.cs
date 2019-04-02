using System.Collections.Generic;
using System.IO;
using System.Net;
using FrsSDK.client.param;
using FrsSDK.common;

namespace FrsSDK.access
{
    public class AccessService
    {
        private readonly AuthInfo authInfo;
        private readonly WebClient webClient;
        private readonly WebProxy proxy;

        public AccessService(client.param.AuthInfo authInfo)
        {
            this.authInfo = authInfo;
            webClient = new WebClient();
        }

        public AccessService(AuthInfo authInfo, ProxyHostInfo proxyHostInfo)
        {
            this.authInfo = authInfo;
            proxy = proxyHostInfo.GetProxy();
        }

        public HttpWebResponse Get(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = WebRequest.CreateHttp(authInfo.EndPoint + url);
            request.Method = "GET";
            return Access(request, null);
        }

        public HttpWebResponse Post(string url, Dictionary<string, string> headers, byte[] content, string contentType)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = WebRequest.CreateHttp(authInfo.EndPoint + url);
            request.Method = "POST";
            //request.Headers.Add("Content-Type", contentType);
            request.ContentType = contentType;
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> pair in headers)
                {
                    request.Headers.Add(pair.Key, pair.Value);
                }
            }
            return Access(request, content);
        }

        public HttpWebResponse Delete(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = WebRequest.CreateHttp(authInfo.EndPoint + url);
            request.Method = "DELETE";
            return Access(request, null);
        }

        private HttpWebResponse Access(HttpWebRequest request, byte[] content)
        {
            if (proxy != null)
            {
                request.Proxy = proxy;
            }
            if (content != null)
            {
                request.GetRequestStream().Write(content, 0, content.Length);
            }
            Signer.Sign(request, content, authInfo.Ak, authInfo.Sk);
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse)
                {
                    int statusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    throw new FrsException(statusCode, reader.ReadToEnd());
                }
                else
                {
                    throw e;
                }
            }
        }

    }
}
