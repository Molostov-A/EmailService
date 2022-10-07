using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EmailServiceWebApi.Interfaces;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi
{
    public class MailsRepository : IMailsRepository
    {
        private static ConcurrentDictionary<string, MailsItem> _mails = new ConcurrentDictionary<string, MailsItem>();
        private readonly EmailSender emailSender;
        public MailsRepository(EmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public void Add(MailsItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            item.Date = DateTime.UtcNow;
            _mails[item.Key] = item;
            emailSender.SendEmailMessage(item);
        }

        public IEnumerable<MailsItem> GetAll()
        {
            return _mails.Values;
        }
    }
}