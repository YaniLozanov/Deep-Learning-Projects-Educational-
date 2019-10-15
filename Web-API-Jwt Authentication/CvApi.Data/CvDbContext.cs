using CvApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvApi.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<AppliactionUser> Users { get; set; }

        public DbSet<UserLog> UserLogs { get; set; }
    }
}
