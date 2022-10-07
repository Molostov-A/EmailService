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


        public void Add(MailsDbItem dbItem)
        {
            dbItem.Id = Guid.NewGuid();
            dbItem.Date = DateTime.UtcNow;
            databaseContext.MailsItems.Add(dbItem);
            databaseContext.SaveChanges();
        }

        public IEnumerable<MailsDbItem> GetAll()
        {
            return databaseContext.MailsItems.ToList();
        }
    }
}