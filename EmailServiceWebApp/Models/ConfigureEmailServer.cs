using System.Text.Json.Serialization;

namespace EmailServiceWebApp.Models
{
    public class ConfigureEmailServer
    {
        [JsonPropertyName ("emailFrom")]
        public string EmailFrom { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("emailTo")]
        public string EmailTo { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}