using FrsSDK.common;
using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class Landmark : JsonObject
    {
        [JsonProperty(PropertyName = "eyes_contour")]
        public PointList eyesContour;

        [JsonProperty(PropertyName = "mouth_contour")]
        public PointList mouthContour;

        [JsonProperty(PropertyName = "face_contour")]
        public PointList faceContour;

        [JsonProperty(PropertyName = "eyebrow_contour")]
        public PointList eyeBrowContour;

        [JsonProperty(PropertyName = "nose_contour")]
        public PointList noseContour;
    }
}
