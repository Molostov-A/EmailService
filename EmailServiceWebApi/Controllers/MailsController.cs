using System.Collections;
using System.Collections.Generic;
using EmailServiceWebApi.Interfaces;
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

        public IEnumerable<MailsItem> GetAll()
        {
            return MailsItems.GetAll();
        }

        [HttpPost]
        public IActionResult Send([FromBody] MailsItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            MailsItems.Add(item);
            return CreatedAtRoute("GetMails", new { id = item.Id }, item);
        }
    }
}
