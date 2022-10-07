using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class ConfigureEmailServer
    {
        [JsonPropertyName ("emailFrom")]
        public string EmailFrom { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}