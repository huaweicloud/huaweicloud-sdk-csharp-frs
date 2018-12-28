using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class CompareService
    {
        private readonly AccessService accessService;
        private readonly string projectId;

        public CompareService(AccessService accessService, string projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private CompareFaceResult CompareFace(string image1, string image2, ImageType imageType)
        {
            string uri = string.Format(FrsConstant.FACE_COMPARE_URI, this.projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image1_base64", image1);
                    jsonObj.Add("image2_base64", image2);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image1_url", image1);
                    jsonObj.Add("image2_url", image2);
                    break;
            }
            HttpWebResponse response = this.accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<CompareFaceResult>(response);
        }

        public CompareFaceResult CompareFaceByBase64(string image1Base64, string image2Base64)
        {
            return this.CompareFace(image1Base64, image2Base64, ImageType.BASE64);
        }

        public CompareFaceResult CompareFaceByUrl(string image1Url, string image2Url)
        {
            return this.CompareFace(image1Url, image2Url, ImageType.URL);
        }

        public CompareFaceResult CompareFaceByFile(string image1Path, string image2Path)
        {
            string uri = string.Format(FrsConstant.FACE_COMPARE_URI, this.projectId);
            MultipartWriter multipart = new MultipartWriter();
            multipart.WriteStart();
            multipart.WriteFile("image1_file", image1Path, image1Path);
            multipart.WriteFile("image2_file", image2Path, image2Path);
            byte[] data = multipart.WriteClose();
            HttpWebResponse response = this.accessService.Post(uri, null, data, multipart.GetContentType());
            return HttpUtils.ResponseToObj<CompareFaceResult>(response);
        }
    }
}
