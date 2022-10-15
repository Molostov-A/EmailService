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

        /// <summary>
        /// Add a record to the database
        /// </summary>
        /// <returns></returns>
        public void Add(MailsItem item)
        {
            item.Id = Guid.NewGuid();
            item.Date = DateTime.UtcNow;
            _db.MailsItems.Add(item);
            _db.Recipients.AddRange(item.Recipients);
            _db.SaveChanges();
        }

        /// <summary>
        /// Return the entire list of recorded data packets to send from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MailsItem> GetAll()
        {
            return _db.MailsItems.Include(r => r.Recipients).ToList();
        }
    }
}