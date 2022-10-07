using System;
using System.Collections.Generic;
using EmailService.Db.Interfaces;
using EmailService.Db.Models;
using EmailServiceWebApi.Helpers;
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

        public IEnumerable<MailsItemGet> GetAll()
        {
            var mails = _mails.GetAll();
            var mailsView = Mapping.ToListMailsItemGet(mails);
            return mailsView;
        }

        [HttpPost]
        public IActionResult Send([FromBody] MailsItemPost itemPostPost)
        {
            if (itemPostPost == null)
            {
                return BadRequest();
            }

            var item = Mapping.ToMailsItem(itemPostPost);
            
            _emailSender.SendEmailMessage(item);
            _mails.Add(item);

            return CreatedAtRoute("GetMails", new { id = item.Id }, item);
        }

        
    }
}
