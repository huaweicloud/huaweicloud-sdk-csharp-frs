using Newtonsoft.Json;

namespace FrsSDK.client.result.common
{
    public class ComplexFace : Face
    {
        [JsonProperty(PropertyName = "similarity")]
        public double similarity;
    }
}
