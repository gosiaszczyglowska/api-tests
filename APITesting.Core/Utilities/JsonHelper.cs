using Newtonsoft.Json;


namespace APITesting.Core.Utilities
{
    public class JsonHelper
    {
        public static T DeserializeObject<T>(string json) 
        {
            if (string.IsNullOrEmpty(json)) 
            {
                throw new AggregateException("JSON content is null or empty");
            }

            return JsonConvert.DeserializeObject<T>(json)
                   ?? throw new JsonSerializationException("Deserialization failed");
        }
    }
}
