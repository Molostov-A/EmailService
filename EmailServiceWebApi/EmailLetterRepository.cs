using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EmailServiceWebApi.Interfaces;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi
{
    public class EmailLetterRepository:IEmailLetterRepository
    {
        private static ConcurrentDictionary<string, EmailLetterItem> _emailLetter = new ConcurrentDictionary<string, EmailLetterItem>();

        public void Add(EmailLetterItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            item.Date = DateTime.UtcNow;
            _emailLetter[item.Key] = item;
        }

        public IEnumerable<EmailLetterItem> GetAll()
        {
            return _emailLetter.Values;
        }
    }
}