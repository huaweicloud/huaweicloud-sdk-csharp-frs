using System;
using FrsSDK.access;
using FrsSDK.client.param;
using FrsSDK.client.service;
using FrsSDK.client.service.v2;

namespace FrsSDK.client
{
    public class FrsClient
    {

        private CompareService compareService;
        private DetectService detectService;
        private FaceService faceService;
        private FaceSetService faceSetService;
        private LiveDetectService liveDetectService;
        private QualityService qualityService;
        private SearchService searchService;

        private ApiCollectionV2 apiCollectionV2;

        public FrsClient(AuthInfo authInfo, String projectId)
        {
            AccessService accessService = new AccessService(authInfo);
            this.InitService(accessService, projectId);
        }

        public FrsClient(AuthInfo authInfo, String projectId, ProxyHostInfo proxyHostInfo)
        {
            AccessService accessService = new AccessService(authInfo, proxyHostInfo);
            this.InitService(accessService, projectId);
        }

        private void InitService(AccessService accessService, String projectId)
        {
            this.compareService = new CompareService(accessService, projectId);
            this.detectService = new DetectService(accessService, projectId);
            this.faceService = new FaceService(accessService, projectId);
            this.faceSetService = new FaceSetService(accessService, projectId);
            this.liveDetectService = new LiveDetectService(accessService, projectId);
            this.qualityService = new QualityService(accessService, projectId);
            this.searchService = new SearchService(accessService, projectId);

            this.apiCollectionV2 = new ApiCollectionV2(accessService, projectId);
        }

        public CompareService GetCompareService()
        {
            return this.compareService;
        }

        public DetectService GetDetectService()
        {
            return this.detectService;
        }

        public FaceService GetFaceService()
        {
            return this.faceService;
        }

        public FaceSetService GetFaceSetService()
        {
            return this.faceSetService; 
        }

        public LiveDetectService GetLiveDetectService()
        {
            return this.liveDetectService;
        }

        public QualityService GetQualityService()
        {
            return this.qualityService;
        }

        public SearchService GetSearchService()
        {
            return this.searchService;
        }

        public ApiCollectionV2 GetV2()
        {
            return this.apiCollectionV2;
        }

    }
}
