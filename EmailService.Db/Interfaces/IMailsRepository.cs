using System.Collections.Generic;
using System.Threading.Tasks;
using EmailService.Db.Models;

namespace EmailService.Db.Interfaces
{
    public interface IMailsRepository
    {
        Task AddAsync(MailsItem item);
        Task<IEnumerable<MailsItem>> GetAllAsync();
    }
}