using EmailService.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Db
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Table MailsItem
        /// </summary>
        public DbSet<MailsItem> MailsItems { get; set; }

        /// <summary>
        /// Table recipients
        /// </summary>
        public DbSet<Recipient> Recipients { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }
    }
}