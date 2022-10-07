using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmailServiceWebApi.Models
{
    public class MailsItemPost
    {

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public List<string> Recipients { get; set; }

    }
}