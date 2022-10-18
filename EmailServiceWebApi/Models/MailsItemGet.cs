using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    /// <summary>
    /// GET request model for MailsItem data output
    /// </summary>
    public class MailsItemGet
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

        /// <summary>
        /// Request date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Sending result (values "OK" "Failed")
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }

        /// <summary>
        /// Error message (blank or contains a notification sending error)
        /// </summary>
        [JsonPropertyName("failedMessage")]
        public string FailedMessage { get; set; }
    }
}