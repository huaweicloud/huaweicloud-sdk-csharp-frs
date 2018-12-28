using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class LiveDetectService
    {
        private readonly AccessService accessService;
        private readonly String projectId;

        public LiveDetectService(AccessService accessService, String projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private LiveDetectResult LiveDetect(string video, ImageType imageType, string actions, string actionTime)
        {
            string uri = String.Format(FrsConstant.LIVE_DETECT_URI, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("video_base64", video);
                    break;
                case ImageType.URL:
                    jsonObj.Add("video_url", video);
                    break;
            }
            jsonObj.Add("actions", actions);
            if (null != actionTime)
            {
                jsonObj.Add("action_time", actionTime);
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<LiveDetectResult>(response);
        }

        public LiveDetectResult LiveDetectByBase64(string videoBase64, string actions, string actionTime)
        {
            return LiveDetect(videoBase64, ImageType.BASE64, actions, actionTime);
        }

        public LiveDetectResult LiveDetectByBase64(string videoBase64, string actions)
        {
            return LiveDetectByBase64(videoBase64, actions, null);
        }

        public LiveDetectResult LiveDetectByUrl(string videoUrl, string actions, string actionTime)
        {
            return LiveDetect(videoUrl, ImageType.URL, actions, actionTime);
        }

        public LiveDetectResult LiveDetectByUrl(string videoUrl, string actions)
        {
            return LiveDetectByUrl(videoUrl, actions, null);
        }

        public LiveDetectResult LiveDetectByFile(string videoPath, string actions, string actionTime)
        {
            string uri = string.Format(FrsConstant.LIVE_DETECT_URI, this.projectId);
            MultipartWriter multipart = new MultipartWriter();
            multipart.WriteStart();
            multipart.WriteFile("video_file", "video_file", videoPath);
            if (null != actions)
            {
                multipart.WriteProperty("actions", actions);
            }
            if (null != actionTime)
            {
                multipart.WriteProperty("action_time", actionTime);
            }
            byte[] data = multipart.WriteClose();
            HttpWebResponse response = this.accessService.Post(uri, null, data, multipart.GetContentType());
            return HttpUtils.ResponseToObj<LiveDetectResult>(response);
        }

        public LiveDetectResult LiveDetectByFile(string videoPath, string actions)
        {
            return LiveDetectByFile(videoPath, actions, null);
        }
    }
}
