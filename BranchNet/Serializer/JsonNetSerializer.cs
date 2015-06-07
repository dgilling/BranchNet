using Newtonsoft.Json;

namespace BranchNet.Serializer
{
    internal class JsonNetSerializer : ISerializer
    {
        public const string DATE_TIME_PATTERN = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

        public JsonNetSerializer()
        {
            Settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver  = new SnakeCaseContractResolver(),
                
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                DateFormatString     = DATE_TIME_PATTERN   
            };
        }

        public JsonSerializerSettings Settings { get; set; }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Settings);
        }
    }
}