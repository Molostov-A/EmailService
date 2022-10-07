using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using System;
using System.Collections.Generic;

namespace EmailServiceWebApi.Helpers
{
    public static class Mapping
    {
        public static List<MailsItemViewGet> ToListMailsItemViewGet(IEnumerable<MailsItem> mails)
        {
            var mailsView = new List<MailsItemViewGet>();
            foreach (var mail in mails)
            {
                var recipients = new List<string>();
                foreach (var recipient in mail.Recipients)
                {
                    recipients.Add(recipient.Email);
                }
                mailsView.Add
                (
                    new MailsItemViewGet()
                    {
                        Body = mail.Body,
                        Subject = mail.Subject,
                        FailedMessage = mail.FailedMessage,
                        Recipients = recipients,
                        Result = mail.Result
                    }
                );
            }
            return mailsView;
        }

        public static MailsItem ToMailsItem(MailsItemViews itemViewsView)
        {
            MailsItem item = new MailsItem();
            List<Recipient> recipients = new List<Recipient>();
            for (int i = 0; i < itemViewsView.Recipients.Count; i++)
            {
                recipients.Add(new Recipient()
                {
                    Id = Guid.NewGuid(),
                    Email = itemViewsView.Recipients[i],
                    MailsItem = item
                });
            }
            item = new MailsItem()
            {
                Subject = itemViewsView.Subject,
                Body = itemViewsView.Body,
                Recipients = recipients
            };
            return item;
        }
    }
}