using EmailService.Db.Models;
using System.Collections.Generic;
using System;

namespace EmailServiceWebApi.Models
{
    public class MailsItemViewGet
    {

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<string> Recipients { get; set; }

        public string Result { get; set; }

        public string FailedMessage { get; set; }
    }
}