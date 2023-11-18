using ISAProject.Modules.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database
{
    public class StakeholdersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyAdmin> CompanyAdmins{ get; set; }
        public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("stakeholders");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CompanyAdmin>().ToTable("CompanyAdmins");

            ConfigureStakeholder(modelBuilder);
        }

        private static void ConfigureStakeholder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyAdmin>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        }
    }
}
