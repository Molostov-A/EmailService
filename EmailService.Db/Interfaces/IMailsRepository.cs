using System.Collections.Generic;
using EmailService.Db.Models;

namespace EmailService.Db.Interfaces
{
    public interface IMailsRepository
    {
        void Add(MailsItem item);
        IEnumerable<MailsItem> GetAll();
    }
}