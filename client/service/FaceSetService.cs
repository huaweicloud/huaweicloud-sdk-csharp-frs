using System;
using System.Collections.Generic;
using System.Net;
using FrsSDK.access;
using FrsSDK.client.param;
using FrsSDK.client.result;
using FrsSDK.common;

namespace FrsSDK.client.service
{
    public class FaceSetService
    {
        private readonly AccessService accessService;
        private readonly String projectId;

        public FaceSetService(AccessService accessService, String projectId)
        {
            this.accessService = accessService;
            this.projectId = projectId;
        }

        public CreateFaceSetResult CreateFaceSet(string faceSetName, int faceSetCapacity, CreateExternalFields createExternalFields)
        {
            string uri = String.Format(FrsConstant.FACE_SET_CREATE_URI, projectId);
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            jsonObj.Add("face_set_name", faceSetName);
            if (0 != faceSetCapacity)
            {
                jsonObj.Add("face_set_capacity", faceSetCapacity);
            }
            if (null != createExternalFields)
            {
                jsonObj.Add("external_fields", createExternalFields.GetValue());
            }
            HttpWebResponse response = accessService.Post(uri, null, HttpUtils.ObjToData(jsonObj), FrsConstant.TYPE_JSON);
            return HttpUtils.ResponseToObj<CreateFaceSetResult>(response);
        }

        public CreateFaceSetResult CreateFaceSet(string faceSetName, int faceSetCapacity)
        {
            return CreateFaceSet(faceSetName, faceSetCapacity, null);
        }

        public CreateFaceSetResult CreateFaceSet(string faceSetName)
        {
            return CreateFaceSet(faceSetName, 0, null);
        }

        public GetAllFaceSetsResult GetAllFaceSets()
        {
            string uri = String.Format(FrsConstant.FACE_SET_GET_ALL_URI, projectId);
            HttpWebResponse response = accessService.Get(uri);
            return HttpUtils.ResponseToObj<GetAllFaceSetsResult>(response);
        }

        public GetFaceSetResult GetFaceSet(string faceSetName)
        {
            string uri = String.Format(FrsConstant.FACE_SET_GET_ONE_URI, projectId, faceSetName);
            HttpWebResponse response = accessService.Get(uri);
            return HttpUtils.ResponseToObj<GetFaceSetResult>(response);
        }

        public DeleteFaceSetResult DeleteFaceSet(string faceSetName)
        {
            string uri = String.Format(FrsConstant.FACE_SET_DELETE_URI, projectId, faceSetName);
            HttpWebResponse response = accessService.Delete(uri);
            return HttpUtils.ResponseToObj<DeleteFaceSetResult>(response);
        }
    }
}
