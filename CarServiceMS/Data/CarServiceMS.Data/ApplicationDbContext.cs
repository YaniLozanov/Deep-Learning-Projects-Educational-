using CarServiceMS.Data.Models;
using CarServiceMS.Data.Models.CarServicesModels;
using CarServiceMS.Data.Models.CarServicesModels.MaintenanceModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarServiceMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // User
        public DbSet<ApplicationUser> User { get; set; }

        // Car
        public DbSet<Car> Cars { get; set; }

        // Car Services
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

        // Car Parts
        public DbSet<RepairPart> RepairParts { get; set; }
        public DbSet<MaintenancePart> MaintenanceParts { get; set; }

        // Car Actions
        public DbSet<ReportedDefect> ReportedDefects { get; set; }
        public DbSet<CompletedAction> CompletedActions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>()
                .HasIndex(u => u.Number)
                .IsUnique(true);
        }
    }
}
