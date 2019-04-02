using System;
using FrsSDK.access;

namespace FrsSDK.client.service.v2
{
    public class ApiCollectionV2
    {
        private readonly CompareServiceV2 compareService;
        private readonly DetectServiceV2 detectService;
        private readonly FaceServiceV2 faceService;
        private readonly FaceSetServiceV2 faceSetService;
        private readonly LiveDetectServiceV2 liveDetectService;
        private readonly SearchServiceV2 searchService;

        public ApiCollectionV2(AccessService accessService, string projectId)
        {
            compareService = new CompareServiceV2(accessService, projectId);
            detectService = new DetectServiceV2(accessService, projectId);
            faceService = new FaceServiceV2(accessService, projectId);
            faceSetService = new FaceSetServiceV2(accessService, projectId);
            liveDetectService = new LiveDetectServiceV2(accessService, projectId);
            searchService = new SearchServiceV2(accessService, projectId);
        }

        public CompareServiceV2 GetCompareService()
        {
            return this.compareService;
        }

        public DetectServiceV2 GetDetectService()
        {
            return this.detectService;
        }

        public FaceServiceV2 GetFaceService()
        {
            return this.faceService;
        }

        public FaceSetServiceV2 GetFaceSetService()
        {
            return this.faceSetService;
        }

        public LiveDetectServiceV2 GetLiveDetectService()
        {
            return this.liveDetectService;
        }

        public SearchServiceV2 GetSearchService()
        {
            return this.searchService;
        }
    }
}
