using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class DetectServiceV2
    {
        private readonly AccessService accessService;
        private readonly String projectId;

        public DetectServiceV2(AccessService accessService, String projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private DetectFaceResult DetectFace(string image, ImageType imageType, string attributes)
        {
            string uri = String.Format(FrsConstantV2.FACE_DETECT_URI, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch(imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image_base64", image);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image_url", image);
                    break;
            }
            if (null != attributes)
            {
                jsonObj.Add("attributes", attributes);
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstantV2.TYPE_JSON);
            return HttpUtils.ResponseToObj<DetectFaceResult>(response);
        }

        //Base64
        public DetectFaceResult DetectFaceByBase64(string imageBase64, string attributes)
        {
            return DetectFace(imageBase64, ImageType.BASE64, attributes);
        }

        public DetectFaceResult DetectFaceByBase64(string imageBase64)
        {
            return DetectFaceByBase64(imageBase64, null);
        }

        //Url
        public DetectFaceResult DetectFaceByUrl(string imageUrl, string attributes)
        {
            return DetectFace(imageUrl, ImageType.URL, attributes);
        }

        public DetectFaceResult DetectFaceByUrl(string imageUrl)
        {
            return DetectFaceByUrl(imageUrl, null);
        }

        //File
        public DetectFaceResult DetectFaceByFile(string imagePath, string attributes)
        {
            string uri = string.Format(FrsConstantV2.FACE_DETECT_URI, this.projectId);
            MultipartWriter multipart = new MultipartWriter();
            multipart.WriteStart();
            multipart.WriteFile("image_file", imagePath, imagePath);
            if (null != attributes)
            {
                multipart.WriteProperty("attributes", attributes);
            }
            byte[] data = multipart.WriteClose();
            HttpWebResponse response = this.accessService.Post(uri, null, data, multipart.GetContentType());
            return HttpUtils.ResponseToObj<DetectFaceResult>(response);
        }

        public DetectFaceResult DetectFaceByFile(string imagePath)
        {
            return DetectFaceByFile(imagePath, null);
        }
    }
}
