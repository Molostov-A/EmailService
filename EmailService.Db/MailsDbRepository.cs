using System;
using System.Collections.Generic;
using System.Linq;
using EmailService.Db.Models;
using EmailService.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Db
{
    public class MailsDbRepository : IMailsRepository
    {
        private readonly DatabaseContext _db;

        public MailsDbRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void Add(MailsItem item)
        {
            item.Id = Guid.NewGuid();
            item.Date = DateTime.UtcNow;
            _db.MailsItems.Add(item);
            _db.Recipients.AddRange(item.Recipients);
            _db.SaveChanges();
        }

        public IEnumerable<MailsItem> GetAll()
        {
            var mails = _db.MailsItems.ToList();
            foreach (var mail in mails)
            {
                var recipients = _db.Recipients.Where(r => r.MailsItem.Id == mail.Id).ToList();
                mail.Recipients = recipients;
            }
            return mails;
        }
    }
}