using Newtonsoft.Json;

namespace AutoBlogger.Models
{
    public class UrlShortener
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("id")]
        public string ShortUrl { get; set; }

        [JsonProperty("longUrl")]
        public string LongUrl { get; set; }
    }
}