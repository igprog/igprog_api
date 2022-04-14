using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class MailContext : DbContext
    {
        public MailContext(DbContextOptions<MailContext> opt) : base(opt)
        {

        }

        public DbSet<Mail> Mails { get; set; }
    }

}