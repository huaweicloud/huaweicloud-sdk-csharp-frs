using System;
using FrsSDK.client;
using FrsSDK.client.param;
using FrsSDK.client.result;

namespace FrsSDK.demo
{
    public class Demo
    {
        public static void Main(String[] args)
        {
            DemoV1();
            DemoV2();
        }

        public static void DemoV1()
        {
            AuthInfo authInfo = new AuthInfo("https://face.cn-north-1.myhuaweicloud.com", "ak", "sk");
            FrsClient frsClient = new FrsClient(authInfo, "project id");
            try
            {
                Console.WriteLine("compare");
                CompareFaceResult compareFaceResult = frsClient.GetCompareService().CompareFaceByUrl("/obs/1.jpg", "/obs/1.jpg");
                Console.WriteLine(compareFaceResult.GetJsonString());
                compareFaceResult = frsClient.GetCompareService().CompareFaceByFile("/resource/1.jpeg", "/resource/1.jpeg");
                Console.WriteLine(compareFaceResult.GetJsonString());

                Console.WriteLine("detect");
                DetectFaceResult detectFaceResult = frsClient.GetDetectService().DetectFaceByUrl("/obs/1.jpg", "0,1,2");
                Console.WriteLine(detectFaceResult.GetJsonString());
                DetectFaceResult detectFaceResult2 = frsClient.GetDetectService().DetectFaceByFile("/resource/1.jpeg", "1,2");
                Console.WriteLine(detectFaceResult2.GetJsonString());

                Console.WriteLine("live detect");
                LiveDetectResult liveDetectResult = frsClient.GetLiveDetectService().LiveDetectByUrl("/obs/1.jpg", "1", "0-1000");
                Console.WriteLine(liveDetectResult.GetJsonString());
                liveDetectResult = frsClient.GetLiveDetectService().LiveDetectByFile("/resource/3.png", "1");
                Console.WriteLine(liveDetectResult.GetJsonString());

                Console.WriteLine("create face set");
                //CreateFaceSetResult createFaceSetResult = frsClient.GetFaceSetService().CreateFaceSet("face_set_name_test");
                //Console.WriteLine(createFaceSetResult.GetJsonString());
                CreateExternalFields createExternalFields = new CreateExternalFields();
                createExternalFields.AddField("testInt", FieldType.INTEGER);
                createExternalFields.AddField("testStr", FieldType.STRING);
                CreateFaceSetResult createFaceSetResult = frsClient.GetFaceSetService().CreateFaceSet("face_set_name_test", 10000, createExternalFields);
                Console.WriteLine(createFaceSetResult.GetJsonString());

                Console.WriteLine("get all face set");
                GetAllFaceSetsResult getAllFaceSetsResult = frsClient.GetFaceSetService().GetAllFaceSets();
                Console.WriteLine(getAllFaceSetsResult.GetJsonString());

                Console.WriteLine("get face set");
                GetFaceSetResult getFaceSetResult = frsClient.GetFaceSetService().GetFaceSet("face_set_name_test");
                Console.WriteLine(getFaceSetResult.GetJsonString());

                Console.WriteLine("add face");
                AddFaceResult addFaceResult = frsClient.GetFaceService().AddFaceByUrl("face_set_name_test", "/obs/1.jpg");
                Console.WriteLine(addFaceResult.GetJsonString());
                AddExternalFields addExternalFields = new AddExternalFields();
                addExternalFields.AddField("testInt", 1);
                addExternalFields.AddField("testStr", "str");
                addFaceResult = frsClient.GetFaceService().AddFaceByFile("face_set_name_test", "/resource/3.png", addExternalFields);
                Console.WriteLine(addFaceResult.GetJsonString());

                Console.WriteLine("get all face");
                GetFaceResult getFaceResult = frsClient.GetFaceService().GetFaces("face_set_name_test", 0, 10);
                Console.WriteLine(getFaceResult.GetJsonString());

                Console.WriteLine("search face");
                SearchFaceResult searchFaceResult = frsClient.GetSearchService().SearchFaceByFile("face_set_name_test", "/resource/3.png", 10, 0.1);
                Console.WriteLine(searchFaceResult.GetJsonString());
                SearchSort searchSort = new SearchSort();
                searchSort.AddSortField("testInt", SortType.ASC);
                SearchReturnFields searchReturnFields = new SearchReturnFields();
                searchReturnFields.AddReturnField("testInt");
                searchFaceResult = frsClient.GetSearchService().SearchFaceByUrl("face_set_name_test", "/obs/1.jpg", 10, 0, searchSort, searchReturnFields, null);
                Console.WriteLine(searchFaceResult.GetJsonString());

                Console.WriteLine("delete face set");
                DeleteFaceSetResult deleteFaceSetResult = frsClient.GetFaceSetService().DeleteFaceSet("face_set_name_test");
                Console.WriteLine(deleteFaceSetResult.GetJsonString());
            }
            catch (Exception e)
            {
                Console.WriteLine("=======ERROR CLEAN==========");
                DeleteFaceSetResult deleteFaceSetResult = frsClient.GetFaceSetService().DeleteFaceSet("face_set_name_test");
                Console.WriteLine(deleteFaceSetResult.GetJsonString());
                Console.WriteLine(e);
            }
        }

        public static void DemoV2()
        {

            // Use FrsClient::GetV2() to get v2 api

            AuthInfo authInfo = new AuthInfo("https://face.cn-north-1.myhuaweicloud.com", "ak", "sk");
            FrsClient frsClient = new FrsClient(authInfo, "project id");
            try
            {
                Console.WriteLine("compare");
                CompareFaceResult compareFaceResult = frsClient.GetV2().GetCompareService().CompareFaceByUrl("/obs/1.jpg", "/obs/1.jpg");
                Console.WriteLine(compareFaceResult.GetJsonString());
                compareFaceResult = frsClient.GetV2().GetCompareService().CompareFaceByFile("/resource/1.jpeg", "/resource/1.jpeg");
                Console.WriteLine(compareFaceResult.GetJsonString());

                Console.WriteLine("detect");
                DetectFaceResult detectFaceResult = frsClient.GetV2().GetDetectService().DetectFaceByUrl("/obs/1.jpg", "0,1,2");
                Console.WriteLine(detectFaceResult.GetJsonString());
                DetectFaceResult detectFaceResult2 = frsClient.GetV2().GetDetectService().DetectFaceByFile("/resource/1.jpeg", "1,2");
                Console.WriteLine(detectFaceResult2.GetJsonString());

                Console.WriteLine("live detect");
                LiveDetectResult liveDetectResult = frsClient.GetV2().GetLiveDetectService().LiveDetectByUrl("/obs/1.jpg", "1", "0-1000");
                Console.WriteLine(liveDetectResult.GetJsonString());
                liveDetectResult = frsClient.GetV2().GetLiveDetectService().LiveDetectByFile("/resource/3.png", "1");
                Console.WriteLine(liveDetectResult.GetJsonString());

                Console.WriteLine("create face set");
                //CreateFaceSetResult createFaceSetResult = frsClient.GetFaceSetService().CreateFaceSet("face_set_name_test");
                //Console.WriteLine(createFaceSetResult.GetJsonString());
                CreateExternalFields createExternalFields = new CreateExternalFields();
                createExternalFields.AddField("testInt", FieldType.INTEGER);
                createExternalFields.AddField("testStr", FieldType.STRING);
                CreateFaceSetResult createFaceSetResult = frsClient.GetV2().GetFaceSetService().CreateFaceSet("face_set_name_test", 10000, createExternalFields);
                Console.WriteLine(createFaceSetResult.GetJsonString());

                Console.WriteLine("get all face set");
                GetAllFaceSetsResult getAllFaceSetsResult = frsClient.GetV2().GetFaceSetService().GetAllFaceSets();
                Console.WriteLine(getAllFaceSetsResult.GetJsonString());

                Console.WriteLine("get face set");
                GetFaceSetResult getFaceSetResult = frsClient.GetV2().GetFaceSetService().GetFaceSet("face_set_name_test");
                Console.WriteLine(getFaceSetResult.GetJsonString());

                Console.WriteLine("add face");
                AddFaceResult addFaceResult = frsClient.GetV2().GetFaceService().AddFaceByUrl("face_set_name_test", "/obs/1.jpg");
                Console.WriteLine(addFaceResult.GetJsonString());
                AddExternalFields addExternalFields = new AddExternalFields();
                addExternalFields.AddField("testInt", 1);
                addExternalFields.AddField("testStr", "str");
                addFaceResult = frsClient.GetV2().GetFaceService().AddFaceByFile("face_set_name_test", "/resource/3.png", addExternalFields);
                Console.WriteLine(addFaceResult.GetJsonString());

                Console.WriteLine("get all face");
                GetFaceResult getFaceResult = frsClient.GetV2().GetFaceService().GetFaces("face_set_name_test", 0, 10);
                Console.WriteLine(getFaceResult.GetJsonString());

                Console.WriteLine("search face");
                SearchFaceResult searchFaceResult = frsClient.GetV2().GetSearchService().SearchFaceByFile("face_set_name_test", "/resource/3.png", 10, 0.1);
                Console.WriteLine(searchFaceResult.GetJsonString());
                SearchSort searchSort = new SearchSort();
                searchSort.AddSortField("testInt", SortType.ASC);
                SearchReturnFields searchReturnFields = new SearchReturnFields();
                searchReturnFields.AddReturnField("testInt");
                searchFaceResult = frsClient.GetV2().GetSearchService().SearchFaceByUrl("face_set_name_test", "/obs/1.jpg", 10, 0, searchSort, searchReturnFields, null);
                Console.WriteLine(searchFaceResult.GetJsonString());

                Console.WriteLine("delete face set");
                DeleteFaceSetResult deleteFaceSetResult = frsClient.GetV2().GetFaceSetService().DeleteFaceSet("face_set_name_test");
                Console.WriteLine(deleteFaceSetResult.GetJsonString());
            }
            catch (Exception e)
            {
                Console.WriteLine("=======ERROR CLEAN==========");
                DeleteFaceSetResult deleteFaceSetResult = frsClient.GetV2().GetFaceSetService().DeleteFaceSet("face_set_name_test");
                Console.WriteLine(deleteFaceSetResult.GetJsonString());
                Console.WriteLine(e);
            }
        }
    }
}
