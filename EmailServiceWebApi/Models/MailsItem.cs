using System;
using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class MailsItem
    {
        [JsonPropertyName("id")]
        public  Guid Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public string[] Recipients { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("failedMessage")]
        public string FailedMessage { get; set; }

    }
}