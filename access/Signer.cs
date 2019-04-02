using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace FrsSDK.access
{
    public static class Signer
    {
        private readonly static string Alg = "SDK-HMAC-SHA256";

        public static void Sign(HttpWebRequest request, byte[] content, string ak, string sk)
        {
            //request.Headers.Add("Host", request.Host);
            string date = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");
            request.Headers.Add("X-Sdk-Date", date);
            string authInfo = CalculateAuthInfo(request, content, ak, sk, date);
            request.Headers.Add("Authorization", authInfo);
        }

        private static string CalculateAuthInfo(HttpWebRequest request, byte[] content, string ak, string sk, string date)
        {
            string contentSha256 = CalcualteContentHash(content);
            string[] signedHeaders = GetSignedHeaders(request);
            string requestString = GetRequestString(request, signedHeaders, contentSha256);
            string stringToSign = GetStringToSign(requestString, date);
            string signature = SignWithSk(stringToSign, sk);
            string authInfo = string.Format("{0} Access={1}, SignedHeaders={2}, Signature={3}",
                Alg,
                ak,
                string.Join(";", signedHeaders),
                signature);
            return authInfo;
        }

        private static string CalcualteContentHash(byte[] content)
        {
            if (content == null)
            {
                content = Encoding.Default.GetBytes("");
            }
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(content);
            return BytesToHex(bytes);
        }

        private static string[] GetSignedHeaders(HttpWebRequest request)
        {
            string[] signedHeaders = new string[request.Headers.AllKeys.Length];
            int i = 0;
            foreach (string key in request.Headers.AllKeys)
            {
                signedHeaders[i] = key.ToLower();
                ++i;
            }
            Array.Sort(signedHeaders);
            return signedHeaders;
        }

        private static string GetRequestString(HttpWebRequest request, string[] signedHeaders, string contentSha256)
        {
            Uri uri = new Uri(Uri.EscapeUriString(request.RequestUri.OriginalString));
            return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
                request.Method,
                uri.AbsolutePath + "/",
                CanonicalQueryString(uri),
                CanonicalHeaders(request),
                string.Join(";", signedHeaders),
                contentSha256);
        }

        private static string CanonicalURI(HttpWebRequest request)
        {
            string[] patterns = request.RequestUri.AbsolutePath.Split('/');
            string[] uri = new string[patterns.Length];
            for (int i = 0; i < patterns.Length; ++i)
            {
                uri[i] = Escape(patterns[i]);
            }
            string urlString = string.Join("/", uri);
            if (urlString.LastIndexOf('/') != urlString.Length - 1)
            {
                urlString = urlString + "/";
            }
            return urlString;
        }

        private static string CanonicalQueryString(Uri uri)
        {
            string[] querys = (uri.Query == "" ? "" : uri.Query.Substring(1)).Split('&');
            Array.Sort(querys, HandleComparison);
            return string.Join("&", querys);
        }

        private static int HandleComparison(string q1, string q2)
        {
            string k1 = q1.Split('=')[0];
            string k2 = q2.Split('=')[0];
            return string.Compare(k1, k2, StringComparison.Ordinal);
        }


        private static string CanonicalHeaders(HttpWebRequest request)
        {
            string[] headers = new string[request.Headers.Count];
            int i = 0;
            foreach (string key in request.Headers.AllKeys)
            {
                headers[i] = key.ToLower() + ":" + request.Headers.Get(key).Trim();
                ++i;
            }
            return string.Format("{0}\n", string.Join("\n", headers));
        }

        private static string GetStringToSign(string requestString, string date)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.Default.GetBytes(requestString));
            string requstHash = BytesToHex(bytes);
            return string.Format("{0}\n{1}\n{2}", Alg, date, requstHash);
        }

        private static string SignWithSk(string stringToSign, string sk)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.Default.GetBytes(sk));
            byte[] bytes = hmac.ComputeHash(Encoding.Default.GetBytes(stringToSign));
            return BytesToHex(bytes);
        }

        private static string BytesToHex(byte[] bytes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in bytes)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        private static bool ShouldEscape(byte c)
        {
            if ('A' <= c && c <= 'Z'
                || 'a' <= c && c <= 'z'
                || '0' <= c && c <= '9'
                || c == '_'
                || c == '-'
                || c == '~'
                || c == '.')
            {
                return false;
            }
            return true;
        }

        private static string Escape(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in s)
            {
                if (ShouldEscape(b))
                {
                    stringBuilder.Append('%');
                    stringBuilder.AppendFormat("{0:x2}", b);
                }
                else
                {
                    stringBuilder.Append(b);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
