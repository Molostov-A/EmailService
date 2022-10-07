using System;
using System.Collections.Generic;

namespace EmailService.Db.Models
{
    public class MailsItem
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<Recipient> Recipients { get; set; }

        public string Result { get; set; }

        public string FailedMessage { get; set; }

    }
}