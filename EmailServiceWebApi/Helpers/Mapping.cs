using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using System;
using System.Collections.Generic;

namespace EmailServiceWebApi.Helpers
{
    public static class Mapping
    {
        public static List<MailsItemGet> ToListMailsItemGet(IEnumerable<MailsItem> mails)
        {
            var mailsView = new List<MailsItemGet>();
            foreach (var mail in mails)
            {
                var recipients = new List<string>();
                foreach (var recipient in mail.Recipients)
                {
                    recipients.Add(recipient.Email);
                }
                mailsView.Add
                (
                    new MailsItemGet()
                    {
                        Body = mail.Body,
                        Subject = mail.Subject,
                        Recipients = recipients,
                        Date = mail.Date,
                        Result = mail.Result,
                        FailedMessage = mail.FailedMessage,
                    }
                );
            }
            return mailsView;
        }

        public static MailsItem ToMailsItem(MailsItemPost itemPostPost)
        {
            MailsItem item = new MailsItem();
            List<Recipient> recipients = new List<Recipient>();
            for (int i = 0; i < itemPostPost.Recipients.Count; i++)
            {
                recipients.Add(new Recipient()
                {
                    Id = Guid.NewGuid(),
                    Email = itemPostPost.Recipients[i],
                    MailsItem = item
                });
            }
            item = new MailsItem()
            {
                Subject = itemPostPost.Subject,
                Body = itemPostPost.Body,
                Recipients = recipients
            };
            return item;
        }
    }
}