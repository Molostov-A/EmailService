using System;
using System.Collections.Generic;
using EmailService.Db.Interfaces;
using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailsRepository _mails;
        private readonly EmailSender _emailSender;
        public MailsController(IMailsRepository mails, EmailSender emailSender)
        {
            _mails = mails;
            _emailSender = emailSender;
        }

        public IEnumerable<MailsItemViewGet> GetAll()
        {
            var mails = _mails.GetAll();
            var mailsView = ConvertToMailsItemViewGet(mails);
            return mailsView;
        }

        private List<MailsItemViewGet> ConvertToMailsItemViewGet(IEnumerable<MailsItem> mails)
        {
            var mailsView = new List<MailsItemViewGet>();
            foreach (var mail in _mails.GetAll())
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

        [HttpPost]
        public IActionResult Send([FromBody] MailsItemViews itemViewsView)
        {
            if (itemViewsView == null)
            {
                return BadRequest();
            }

            var item = ConvertToMailsItem(itemViewsView);
            
            _emailSender.SendEmailMessage(item);
            _mails.Add(item);

            return CreatedAtRoute("GetMails", new { id = item.Id }, item);
        }

        private MailsItem ConvertToMailsItem(MailsItemViews itemViewsView)
        {
            MailsItem item = new MailsItem();
            List<Recipient> recipients = new List<Recipient>();
            for (int i=0; i<itemViewsView.Recipients.Count; i++)
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
