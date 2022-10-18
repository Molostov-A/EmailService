using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    /// <summary>
    /// POST request model for MailsItem
    /// </summary>
    public class MailsItemPost
    {
        /// <summary>
        /// The header of the email to be sent
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The content of the email to be sent
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// Email recipients
        /// </summary>
        [JsonPropertyName("recipients")]
        public List<string> Recipients { get; set; }
    }
}