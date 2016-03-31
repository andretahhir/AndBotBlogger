using Newtonsoft.Json;
using System.Collections.Generic;

namespace AutoBlogger.Models
{
    public class Post
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("labels")]
        public IList<string> Labels { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public PostType PostType { get; set; }

        public string StarsValue { get; set; }

        public string Description { get; set; }

        public string Developer { get; set; }

        public string Downloads { get; set; }

        public bool Live
        {
            get { return Status == "LIVE" ? true : false; }
        }
    }

    public class Blog
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }
    }

    public enum PostType
    {
        None,
        Game,
        Application,
        TopGames,
        TopApps,
        WeekResume
    }
}