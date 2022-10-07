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

        public IEnumerable<MailsItem> GetAll()
        {
            return _mails.GetAll();
        }

        [HttpPost]
        public IActionResult Send([FromBody] MailsItemViews itemViewsView)
        {
            if (itemViewsView == null)
            {
                return BadRequest();
            }

            var item = new MailsItem()
            {
                Subject = itemViewsView.Subject,
                Body = itemViewsView.Body,
                Recipients = itemViewsView.Recipients
            };
            _emailSender.SendEmailMessage(item);
            _mails.Add(item);

            return CreatedAtRoute("GetMails", new { id = item.Id }, item);
        }
    }
}
