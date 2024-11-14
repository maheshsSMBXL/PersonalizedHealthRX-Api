using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace PersonalizedHealthRX_Api.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LogEvents> LogEvents { get; set; }
        public DbSet<LoggedWebHookData> LoggedWebHookData { get; set; }
        public DbSet<User> User { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
