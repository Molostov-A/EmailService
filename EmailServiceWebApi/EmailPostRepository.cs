using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EmailServiceWebApi.Interfaces;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi
{
    public class EmailPostRepository:IEmailPostRepository
    {
        private static ConcurrentDictionary<string, EmailPostItem> _emailPost = new ConcurrentDictionary<string, EmailPostItem>();

        public void Add(EmailPostItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            item.Date = DateTime.UtcNow;
            _emailPost[item.Key] = item;
        }

        public IEnumerable<EmailPostItem> GetAll()
        {
            return _emailPost.Values;
        }
    }
}