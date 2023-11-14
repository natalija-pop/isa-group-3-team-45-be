using ISAProject.Modules.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database
{
    public class StakeholdersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("stakeholders");

            ConfigureStakeholder(modelBuilder);
        }

        private static void ConfigureStakeholder(ModelBuilder modelBuilder)
        {

        }
    }
}
