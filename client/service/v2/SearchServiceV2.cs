using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.param;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class SearchServiceV2
    {
        private readonly AccessService accessService;
        private readonly string projectId;

        public SearchServiceV2(AccessService accessService, string projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private SearchFaceResult SearchFace(string faceSetName, string image, ImageType imageType, int topN, double threshold,
            SearchSort searchSort, SearchReturnFields searchReturnFields, string filter)
        {
            string uri = string.Format(FrsConstantV2.FACE_SEARCH_URI, projectId, faceSetName);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            switch (imageType)
            {
                case ImageType.BASE64:
                    jsonObj.Add("image_base64", image);
                    break;
                case ImageType.URL:
                    jsonObj.Add("image_url", image);
                    break;
                case ImageType.FACEID:
                    jsonObj.Add("face_id", image);
                    break;
            }
            if (-1 != topN)
            {
                jsonObj.Add("top_n", topN);
            }
            if (Math.Abs(threshold) > 0)
            {
                jsonObj.Add("threshold", threshold);
            }
            if (null != searchSort)
            {
                jsonObj.Add("sort", searchSort.GetValue());
            }
            if (null != searchReturnFields)
            {
                jsonObj.Add("return_fields", searchReturnFields.GetValue());
            }
            if (null != filter)
            {
                jsonObj.Add("filter", filter);
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstantV2.TYPE_JSON);
            return HttpUtils.ResponseToObj<SearchFaceResult>(response);
        }

        public SearchFaceResult SearchFaceByBase64(string faceSetName, string imageBase64, int topN, double threshold,
            SearchSort searchSort, SearchReturnFields searchReturnFields, string filter)
        {
            return SearchFace(faceSetName, imageBase64, ImageType.BASE64, topN, threshold, searchSort, searchReturnFields, filter);
        }

        public SearchFaceResult SearchFaceByBase64(string faceSetName, string imageBase64, int topN, double threshold)
        {
            return SearchFaceByBase64(faceSetName, imageBase64, topN, threshold, null, null, null);
        }

        public SearchFaceResult SearchFaceByBase64(string faceSetName, string imageBase64)
        {
            return SearchFaceByBase64(faceSetName, imageBase64, -1, 0, null, null, null);
        }

        public SearchFaceResult SearchFaceByUrl(string faceSetName, string imageUrl, int topN, double threshold,
            SearchSort searchSort, SearchReturnFields searchReturnFields, string filter)
        {
            return SearchFace(faceSetName, imageUrl, ImageType.URL, topN, threshold, searchSort, searchReturnFields, filter);
        }

        public SearchFaceResult SearchFaceByUrl(string faceSetName, string imageUrl, int topN, double threshold)
        {
            return SearchFaceByUrl(faceSetName, imageUrl, topN, threshold, null, null, null);
        }

        public SearchFaceResult SearchFaceByUrl(string faceSetName, string imageUrl)
        {
            return SearchFaceByUrl(faceSetName, imageUrl, -1, 0, null, null, null);
        }

        public SearchFaceResult SearchFaceByFaceId(string faceSetName, string faceId, int topN, double threshold,
            SearchSort searchSort, SearchReturnFields searchReturnFields, string filter)
        {
            return SearchFace(faceSetName, faceId, ImageType.FACEID, topN, threshold, searchSort, searchReturnFields, filter);
        }

        public SearchFaceResult SearchFaceByFaceId(string faceSetName, string faceId, int topN, double threshold)
        {
            return SearchFaceByFaceId(faceSetName, faceId, topN, threshold, null, null, null);
        }

        public SearchFaceResult SearchFaceByFaceId(string faceSetName, string faceId)
        {
            return SearchFaceByFaceId(faceSetName, faceId, -1, 0, null, null, null);
        }

        public SearchFaceResult SearchFaceByFile(string faceSetName, string imagePath, int topN, double threshold,
            SearchSort searchSort, SearchReturnFields searchReturnFields, string filter)
        {
            string uri = string.Format(FrsConstantV2.FACE_SEARCH_URI, this.projectId, faceSetName);
            MultipartWriter multipart = new MultipartWriter();
            multipart.WriteStart();
            multipart.WriteFile("image_file", imagePath, imagePath);
            //top n
            if (-1 != topN)
            {
                multipart.WriteProperty("top_n", topN.ToString());
            }
            //threshold
            if (Math.Abs(threshold) > 0)
            {
                multipart.WriteProperty("threshold", threshold.ToString());
            }
            //search sort
            if (null != searchSort)
            {
                multipart.WriteProperty("sort", searchSort.GetString());
            }
            //return fields
            if (null != searchReturnFields)
            {
                multipart.WriteProperty("return_fields", searchReturnFields.GetString());
            }
            //filter
            if (null != filter)
            {
                multipart.WriteProperty("filter", filter);
            }
            byte[] data = multipart.WriteClose();
            HttpWebResponse response = this.accessService.Post(uri, null, data, multipart.GetContentType());
            return HttpUtils.ResponseToObj<SearchFaceResult>(response);
        }

        public SearchFaceResult SearchFaceByFile(string faceSetName, string imageBase64, int topN, double threshold)
        {
            return SearchFaceByFile(faceSetName, imageBase64, topN, threshold, null, null, null);
        }

        public SearchFaceResult SearchFaceByFile(string faceSetName, string imageBase64)
        {
            return SearchFaceByFile(faceSetName, imageBase64, -1, 0, null, null, null);
        }

    }
}
