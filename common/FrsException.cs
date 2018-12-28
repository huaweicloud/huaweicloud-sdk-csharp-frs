using System;
namespace FrsSDK.common
{
    public class FrsException : Exception
    {
        public readonly int httpCode;
        public readonly String msg;

        public FrsException(int httpCode, String msg)
            : base(String.Format("Http error, status code : {0}, detail: {1}", httpCode, msg))
        {
            this.httpCode = httpCode;
            this.msg = msg;
        }
    }
}
