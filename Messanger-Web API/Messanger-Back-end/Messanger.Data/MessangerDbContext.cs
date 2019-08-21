using Messanger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Data
{
    public class MessangerDbContext : DbContext
    {
        public MessangerDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

    }
}
