using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class EmailPostItem
    {
        [JsonPropertyName("key")]
        public  string Key { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public string[] Recipients { get; set; }

    }
}