using EmailService.Db.Models;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class MailsItemGet
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public List<string> Recipients { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("failedMessage")]
        public string FailedMessage { get; set; }
    }
}