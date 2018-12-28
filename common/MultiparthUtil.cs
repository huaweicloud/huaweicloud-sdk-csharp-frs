using System;
using System.IO;
using System.Text;

namespace FrsSDK.common
{
    public class MultipartWriter
    {
        private readonly string boundary;
        private MemoryStream stream;

        public MultipartWriter()
        {
            this.boundary = "----FrsSdk" + DateTime.Now.ToString("yyyyMMddTHHmmssZ");
        }

        public void WriteStart()
        {
            if (stream != null)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                stream = new MemoryStream();
            }
        }

        public void WriteFile(string propertyName, string fileName, string filePath)
        {
            //Write boundary
            byte[] boundaryBytes = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            //Write header
            string fileHeader = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n",
                propertyName, fileName);
            byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);
            stream.Write(headerBytes, 0, headerBytes.Length);
            //Write file
            byte[] data = File.ReadAllBytes(filePath);
            stream.Write(data, 0, data.Length);
            //Write end
            byte[] endBytes = Encoding.UTF8.GetBytes("\r\n");
            stream.Write(endBytes, 0, endBytes.Length);
        }

        public void WriteProperty(string propertyName, string propertyValue)
        {
            //Write boundary
            byte[] boundaryBytes = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            //Write
            string fileHeader = string.Format("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n",
                propertyName, propertyValue);
            byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);
            stream.Write(headerBytes, 0, headerBytes.Length);
        }

        public byte[] WriteClose()
        {
            byte[] boundaryBytes = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            byte[] data = stream.ToArray();
            stream = null;
            return data;
        }

        public string GetContentType()
        {
            return String.Format(FrsConstant.TYPE_MULTIPART, boundary);
        }
    }
}
