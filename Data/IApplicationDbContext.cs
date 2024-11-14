using Microsoft.EntityFrameworkCore;

namespace PersonalizedHealthRX_Api.Data
{
    public interface IApplicationDbContext
    {
        DbSet<LogEvents> LogEvents { get; set; }
        DbSet<LoggedWebHookData> LoggedWebHookData { get; set; }

        int SaveChanges();
    }
}
