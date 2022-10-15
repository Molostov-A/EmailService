using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using System;
using System.Collections.Generic;

namespace EmailServiceWebApi.Helpers
{
    public static class Mapping
    {
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