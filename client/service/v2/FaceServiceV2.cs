using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.param;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class FaceServiceV2
    {
        private readonly AccessService accessService;
        private readonly String projectId;

        public FaceServiceV2(AccessService accessService, String projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        private AddFaceResult AddFace(string faceSetName, string externalImageId, string image, ImageType imageType, AddExternalFields addExternalFields)
        {
            string uri = String.Format(FrsConstantV2.FACE_ADD_URI, projectId, faceSetName);
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
            if (null != externalImageId)
            {
                jsonObj.Add("external_image_id", externalImageId);
            }
            if (null != addExternalFields)
            {
                jsonObj.Add("external_fields", addExternalFields.GetValue());
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstantV2.TYPE_JSON);
            return HttpUtils.ResponseToObj<AddFaceResult>(response);
        }

        public AddFaceResult AddFaceByBase64(string faceSetName, string externalImageId, string imageBase64, AddExternalFields addExternalFields)
        {
            return AddFace(faceSetName, externalImageId, imageBase64, ImageType.BASE64, addExternalFields);
        }

        public AddFaceResult AddFaceByBase64(string faceSetName, string imageBase64, AddExternalFields addExternalFields)
        {
            return AddFaceByBase64(faceSetName, null, imageBase64, addExternalFields);
        }

        public AddFaceResult AddFaceByBase64(string faceSetName, string externalImageId, string imageBase64)
        {
            return AddFaceByBase64(faceSetName, externalImageId, imageBase64, null);
        }

        public AddFaceResult AddFaceByBase64(string faceSetName, string imageBase64)
        {
            return AddFaceByBase64(faceSetName, null, imageBase64, null);
        }

        //URL
        public AddFaceResult AddFaceByUrl(string faceSetName, string externalImageId, string imageUrl, AddExternalFields addExternalFields)
        {
            return AddFace(faceSetName, externalImageId, imageUrl, ImageType.URL, addExternalFields);
        }

        public AddFaceResult AddFaceByUrl(string faceSetName, string imageUrl, AddExternalFields addExternalFields)
        {
            return AddFaceByUrl(faceSetName, null, imageUrl, addExternalFields);
        }

        public AddFaceResult AddFaceByUrl(string faceSetName, string externalImageId, string imageUrl)
        {
            return AddFaceByUrl(faceSetName, externalImageId, imageUrl, null);
        }

        public AddFaceResult AddFaceByUrl(string faceSetName, string imageUrl)
        {
            return AddFaceByUrl(faceSetName, null, imageUrl, null);
        }

        //FILE
        public AddFaceResult AddFaceByFile(string faceSetName, string externalImageId, string imagePath, AddExternalFields addExternalFields)
        {
            string uri = string.Format(FrsConstantV2.FACE_ADD_URI, this.projectId, faceSetName);
            MultipartWriter multipart = new MultipartWriter();
            multipart.WriteStart();
            multipart.WriteFile("image_file", imagePath, imagePath);
            if (null != externalImageId)
            {
                multipart.WriteProperty("external_image_id", externalImageId);
            }
            if (null != addExternalFields)
            {
                multipart.WriteProperty("external_fields", addExternalFields.GetValue());
            }
            byte[] data = multipart.WriteClose();
            HttpWebResponse response = this.accessService.Post(uri, null, data, multipart.GetContentType());
            return HttpUtils.ResponseToObj<AddFaceResult>(response);
        }

        public AddFaceResult AddFaceByFile(string faceSetName, string imagePath, AddExternalFields addExternalFields)
        {
            return AddFaceByFile(faceSetName, null, imagePath, addExternalFields);
        }

        public AddFaceResult AddFaceByFile(string faceSetName, string externalImageId, string imagePath)
        {
            return AddFaceByFile(faceSetName, externalImageId, imagePath, null);
        }

        public AddFaceResult AddFaceByFile(string faceSetName, string imagePath)
        {
            return AddFaceByFile(faceSetName, null, imagePath, null);
        }

        public GetFaceResult GetFaces(string faceSetName, int offset, int limit)
        {
            string uri = String.Format(FrsConstantV2.FACE_GET_RANGE_URI, projectId, faceSetName, offset, limit);
            HttpWebResponse response = accessService.Get(uri);
            return HttpUtils.ResponseToObj<GetFaceResult>(response);
        }

        public GetFaceResult GetFace(string faceSetName, string faceId)
        {
            string uri = String.Format(FrsConstantV2.FACE_GET_ONE_URI, projectId, faceSetName, faceId);
            HttpWebResponse response = accessService.Get(uri);
            return HttpUtils.ResponseToObj<GetFaceResult>(response);
        }

        public DeleteFaceResult DeleteFaceByFaceId(string faceSetName, string faceId)
        {
            string uri = String.Format(FrsConstantV2.FACE_DELETE_BY_FACE_ID_URI, projectId, faceSetName, faceId);
            HttpWebResponse response = accessService.Delete(uri);
            return HttpUtils.ResponseToObj<DeleteFaceResult>(response);
        }

        public DeleteFaceResult DeleteFaceByExternalImageId(string faceSetName, string externalImageId)
        {
            string uri = String.Format(FrsConstantV2.FACE_DELETE_BY_EXT_ID_URI, projectId, faceSetName, externalImageId);
            HttpWebResponse response = accessService.Delete(uri);
            return HttpUtils.ResponseToObj<DeleteFaceResult>(response);
        }

        public DeleteFaceResult DeleteFaceByFieldId(string faceSetName, string fieldName, string fieldValue)
        {
            string uri = String.Format(FrsConstantV2.FACE_DELETE_BY_FIELD_ID_URI, projectId, faceSetName, fieldName, fieldValue);
            HttpWebResponse response = accessService.Delete(uri);
            return HttpUtils.ResponseToObj<DeleteFaceResult>(response);
        }
    }
}
