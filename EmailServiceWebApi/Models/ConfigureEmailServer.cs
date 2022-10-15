using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    /// <summary>
    /// SMTP server configuration
    /// </summary>
    public class ConfigureEmailServer
    {
        public string EmailFrom { get; set; }
        public string Password { get; set; }
        public string TitleMail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool RemoveAuthenticationMechanism { get; set; }
        public string TypeTokenAuthenticationMechanism { get; set; }

    }
}