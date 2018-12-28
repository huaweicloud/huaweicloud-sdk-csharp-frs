using System.Net;

namespace FrsSDK.client.param
{
    public class ProxyHostInfo
    {
        private readonly string host;
        private readonly int port;
        private readonly string userName;
        private readonly string userPwd;

        public ProxyHostInfo(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public ProxyHostInfo(string host, int port, string userName, string userPwd)
        {
            this.host = host;
            this.port = port;
            this.userName = userName;
            this.userPwd = userPwd;
        }

        public WebProxy GetProxy()
        {
            WebProxy webProxy = new WebProxy(host, port);
            if (userName != null)
            {
                webProxy.Credentials = new NetworkCredential(userName, userPwd);
            }
            return webProxy;
        }
    }
}
