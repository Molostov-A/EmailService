using System;

namespace EmailService.Db.Models
{
    public class Recipient
    {
        public Guid Id { get; set; }
        public MailsItem MailsItem { get; set; }
        public string Email { get; set; }
    }
}