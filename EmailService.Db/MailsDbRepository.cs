using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EmailService.Db.Models;
using EmailService.Db.Interfaces;

namespace EmailService.Db
{
    public class MailsDbRepository : IMailsRepository
    {
        private static ConcurrentDictionary<Guid, MailsDbItem> _mails = new ConcurrentDictionary<Guid, MailsDbItem>();


        public void Add(MailsDbItem dbItem)
        {
            dbItem.Id = Guid.NewGuid();
            dbItem.Date = DateTime.UtcNow;
            _mails[dbItem.Id] = dbItem;
        }

        public IEnumerable<MailsDbItem> GetAll()
        {
            return _mails.Values;
        }
    }
}