using EmailService.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Db
{
    public class DatabaseContext: DbContext
    {
        // Доступ к таблицам
        public DbSet<MailsItem> MailsItems { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        
    }
}