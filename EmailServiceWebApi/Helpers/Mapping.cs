using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailServiceWebApi.Helpers
{
    /// <summary>
    /// Mapping for cases when it is not convenient to use the automapper
    /// </summary>
    public class Mapping
    {
        /// <summary>
        /// Mapping the POST query model (MailsItemPos) to the query storage model in the database (MailsItem)
        /// </summary>
        /// <param name="itemPost">POST request model for MailsItem</param>
        /// <returns></returns>
        public async Task<MailsItem> ToMailsItemAsync(MailsItemPost itemPost)
        {
            MailsItem item = new MailsItem();
            List<Recipient> recipients = new List<Recipient>();
            for (int i = 0; i < itemPost.Recipients.Count; i++)
            {
                recipients.Add(new Recipient()
                {
                    Id = Guid.NewGuid(),
                    Email = itemPost.Recipients[i],
                    MailsItem = item
                });
            }
            item = new MailsItem()
            {
                Subject = itemPost.Subject,
                Body = itemPost.Body,
                Recipients = recipients
            };
            return item;
        }
    }
}