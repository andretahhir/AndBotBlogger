using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AutoBlogger.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        [XmlElement("AcessToken")]
        public string AcessToken { get; set; }

        [JsonProperty("token_type")]
        [XmlElement("TokenType")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        [XmlElement("ExpiresIn")]
        public string ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        [XmlElement("RefreshToken")]
        public string RefreshToken { get; set; }

        [XmlElement("CreateDate")]
        public DateTime CreateDate { get; set; }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            CreateDate = DateTime.Now;
        }
    }
}