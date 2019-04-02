using System;
namespace FrsSDK.common
{
    public static class FrsConstant
    {
        public static readonly string FACE_DETECT_URI = "/v1/{0}/face-detect";
        public static readonly string FACE_COMPARE_URI = "/v1/{0}/face-compare";
        public static readonly string FACE_SEARCH_URI = "/v1/{0}/face-sets/{1}/search";
        public static readonly string FACE_ADD_URI = "/v1/{0}/face-sets/{1}/faces";
        public static readonly string FACE_GET_RANGE_URI = "/v1/{0}/face-sets/{1}/faces?offset={2}&limit={3}";
        public static readonly string FACE_GET_ONE_URI = "/v1/{0}/face-sets/{1}/faces?face_id={2}";
        public static readonly string FACE_DELETE_BY_EXT_ID_URI = "/v1/{0}/face-sets/{1}/faces?external_image_id={2}";
        public static readonly string FACE_DELETE_BY_FACE_ID_URI = "/v1/{0}/face-sets/{1}/faces?face_id={2}";
        public static readonly string FACE_DELETE_BY_FIELD_ID_URI = "/v1/{0}/face-sets/{1}/faces?{2}={3}";
        public static readonly string FACE_SET_CREATE_URI = "/v1/{0}/face-sets";
        public static readonly string FACE_SET_GET_ALL_URI = "/v1/{0}/face-sets";
        public static readonly string FACE_SET_GET_ONE_URI = "/v1/{0}/face-sets/{1}";
        public static readonly string FACE_SET_DELETE_URI = "/v1/{0}/face-sets/{1}";
        public static readonly string LIVE_DETECT_URI = "/v1/{0}/live-detect";
        public static readonly string FACE_QUALITY_URI = "/v1/{0}/face/quality/face-quality";
        public static readonly string BLUR_CLASSOFY_URI = "/v1/{0}/face/quality/blur-classify";
        public static readonly string HEAD_POSE_ESTIMATE = "/v1/{0}/face/quality/head-pose-estimate";

        public static readonly string TYPE_JSON = "application/json; charset=utf-8";
        public static readonly string TYPE_MULTIPART = "multipart/form-data; boundary={0}";
    }

    public static class FrsConstantV2
    {
        public static readonly string FACE_DETECT_URI = "/v2/{0}/face-detect";
        public static readonly string FACE_COMPARE_URI = "/v2/{0}/face-compare";
        public static readonly string FACE_SEARCH_URI = "/v2/{0}/face-sets/{1}/search";
        public static readonly string FACE_ADD_URI = "/v2/{0}/face-sets/{1}/faces";
        public static readonly string FACE_GET_RANGE_URI = "/v2/{0}/face-sets/{1}/faces?offset={2}&limit={3}";
        public static readonly string FACE_GET_ONE_URI = "/v2/{0}/face-sets/{1}/faces?face_id={2}";
        public static readonly string FACE_DELETE_BY_EXT_ID_URI = "/v2/{0}/face-sets/{1}/faces?external_image_id={2}";
        public static readonly string FACE_DELETE_BY_FACE_ID_URI = "/v2/{0}/face-sets/{1}/faces?face_id={2}";
        public static readonly string FACE_DELETE_BY_FIELD_ID_URI = "/v2/{0}/face-sets/{1}/faces?{2}={3}";
        public static readonly string FACE_SET_CREATE_URI = "/v2/{0}/face-sets";
        public static readonly string FACE_SET_GET_ALL_URI = "/v2/{0}/face-sets";
        public static readonly string FACE_SET_GET_ONE_URI = "/v2/{0}/face-sets/{1}";
        public static readonly string FACE_SET_DELETE_URI = "/v2/{0}/face-sets/{1}";
        public static readonly string LIVE_DETECT_URI = "/v2/{0}/live-detect";
        public static readonly string FACE_QUALITY_URI = "/v2/{0}/face/quality/face-quality";
        public static readonly string BLUR_CLASSOFY_URI = "/v2/{0}/face/quality/blur-classify";
        public static readonly string HEAD_POSE_ESTIMATE = "/v2/{0}/face/quality/head-pose-estimate";

        public static readonly string TYPE_JSON = "application/json; charset=utf-8";
        public static readonly string TYPE_MULTIPART = "multipart/form-data; boundary={0}";
    }
}
