using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class QualityService
    {
        private readonly AccessService accessService;
        private readonly String projectId;

        public QualityService(AccessService accessService, String projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private FaceQualityResult FaceQuality(string image, ImageType imageType)
        {
            string uri = String.Format(FrsConstant.FACE_QUALITY_URI, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image_base64", image);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image_url", image);
                    break;
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<FaceQualityResult>(response);
        }

        public FaceQualityResult FaceQualityByFace64(string imageBase64)
        {
            return FaceQuality(imageBase64, ImageType.BASE64);
        }

        public FaceQualityResult FaceQualityByUrl(string imageUrl)
        {
            return FaceQuality(imageUrl, ImageType.URL);
        }

        public FaceQualityResult FaceQualityByFile(string imagePath)
        {
            return FaceQuality(HttpUtils.LoadFileToBase64(imagePath), ImageType.BASE64);
        }

        private BlurClassifyResult BlurClassify(string image, ImageType imageType)
        {
            string uri = String.Format(FrsConstant.BLUR_CLASSOFY_URI, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image_base64", image);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image_url", image);
                    break;
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<BlurClassifyResult>(response);
        }

        public BlurClassifyResult BlurClassifyByBase64(string imageBase64)
        {
            return BlurClassify(imageBase64, ImageType.BASE64);
        }

        public BlurClassifyResult BlurClassifyByUrl(string imageUrl)
        {
            return BlurClassify(imageUrl, ImageType.URL);
        }

        public BlurClassifyResult BlurClassifyByFile(string imagePath)
        {
            return BlurClassify(HttpUtils.LoadFileToBase64(imagePath), ImageType.BASE64);
        }

        private HeadPoseEstimateResult HeadPoseEstimate(string image, ImageType imageType)
        {
            string uri = String.Format(FrsConstant.HEAD_POSE_ESTIMATE, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image_base64", image);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image_url", image);
                    break;
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<HeadPoseEstimateResult>(response);
        }

        public HeadPoseEstimateResult HeadPoseEstimateByBase64(string imageBase64)
        {
            return HeadPoseEstimate(imageBase64, ImageType.BASE64);
        }

        public HeadPoseEstimateResult HeadPoseEstimateByUrl(string imageUrl)
        {
            return HeadPoseEstimate(imageUrl, ImageType.URL);
        }

        public HeadPoseEstimateResult HeadPoseEstimateByFile(string imagePath)
        {
            return HeadPoseEstimate(HttpUtils.LoadFileToBase64(imagePath), ImageType.BASE64);
        }
    }
}
