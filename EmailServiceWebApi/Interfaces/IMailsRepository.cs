using System.Collections.Generic;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi.Interfaces
{
    public interface IMailsRepository
    {
        void Add(MailsItem item);
        IEnumerable<MailsItem> GetAll();
    }
}