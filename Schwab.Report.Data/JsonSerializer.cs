using Newtonsoft.Json;

namespace Schwab.Report.Data
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T message)
        {
            return JsonConvert.SerializeObject(message, new JsonSerializerSettings());
        }

        public T Deserialize<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}
