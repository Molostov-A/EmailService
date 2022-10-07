using System.Collections;
using System.Collections.Generic;
using EmailService.Db.Interfaces;
using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        public IMailsRepository MailsItems { get; set; }
        public MailsController(IMailsRepository mails)
        {
            MailsItems = mails;
        }

        public IEnumerable<MailsDbItem> GetAll()
        {
            return MailsItems.GetAll();
        }

        [HttpPost]
        public IActionResult Send([FromBody] MailsItem itemView)
        {
            if (itemView == null)
            {
                return BadRequest();
            }

            var item = new MailsDbItem()
            {
                Subject = itemView.Subject,
                Body = itemView.Body,
                Recipients = itemView.Recipients
            };

            MailsItems.Add(item);
            return CreatedAtRoute("GetMails", new { id = item.Id }, item);
        }
    }
}
