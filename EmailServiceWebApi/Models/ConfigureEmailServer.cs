using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    /// <summary>
    /// SMTP server configuration
    /// </summary>
    public class ConfigureEmailServer
    {
        [JsonPropertyName ("emailFrom")]
        public string EmailFrom { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}