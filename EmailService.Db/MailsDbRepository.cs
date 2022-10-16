using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// AddAsync a record to the database
        /// </summary>
        /// <returns></returns>
        public async Task AddAsync(MailsItem item)
        {
            item.Id = Guid.NewGuid();
            item.Date = DateTime.UtcNow;
            await _db.MailsItems.AddAsync(item);
            await _db.Recipients.AddRangeAsync(item.Recipients);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Return the entire list of recorded data packets to send from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MailsItem>> GetAllAsync()
        {
            return await _db.MailsItems
                .Include(r => r.Recipients)
                .AsNoTracking().ToListAsync();
        }
    }
}