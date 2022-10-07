﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EmailService.Db.Interfaces;
using EmailService.Db.Models;

namespace EmailServiceWebApi
{
    public class MailsRepository : IMailsRepository
    {
        private static ConcurrentDictionary<Guid, MailsDbItem> _mails = new ConcurrentDictionary<Guid, MailsDbItem>();
        private readonly EmailSender emailSender;
        public MailsRepository(EmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public void Add(MailsDbItem dbItem)
        {
            dbItem.Id = Guid.NewGuid();
            dbItem.Date = DateTime.UtcNow;
            _mails[dbItem.Id] = dbItem;

            emailSender.SendEmailMessage(dbItem);
        }

        public IEnumerable<MailsDbItem> GetAll()
        {
            return _mails.Values;
        }
    }
}