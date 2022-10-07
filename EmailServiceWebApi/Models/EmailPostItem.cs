using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class EmailPostItem
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public string[] Recipients { get; set; }

    }
}