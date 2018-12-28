namespace FrsSDK.client.param
{
    public class AuthInfo
    {
        public AuthInfo(string endPoint, string ak, string sk)
        {
            this.EndPoint = endPoint;
            this.Ak = ak;
            this.Sk = sk;
        }

        public string EndPoint { get; }

        public string Sk { get; }

        public string Ak { get; }
    }
}
