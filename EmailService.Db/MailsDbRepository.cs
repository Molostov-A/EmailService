using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EmailService.Db.Models;
using EmailService.Db.Interfaces;

namespace EmailService.Db
{
    public class MailsDbRepository : IMailsRepository
    {
        private readonly DatabaseContext databaseContext;

        public MailsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        public void Add(MailsItem item)
        {
            item.Id = Guid.NewGuid();
            item.Date = DateTime.UtcNow;
            databaseContext.MailsItems.Add(item);
            databaseContext.SaveChanges();
        }

        public IEnumerable<MailsItem> GetAll()
        {
            return databaseContext.MailsItems.ToList();
        }
    }
}