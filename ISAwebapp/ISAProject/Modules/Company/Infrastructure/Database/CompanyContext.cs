using ISAProject.Modules.Company.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Company.Infrastructure.Database
{
    public class CompanyContext: DbContext
    {
        public DbSet<Core.Domain.Company> Companies { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("company");


            modelBuilder.Entity<Core.Domain.Company>().ToTable("Companies");
            modelBuilder.Entity<Core.Domain.Company>()
                .Property(item => item.Address).HasColumnType("jsonb");
            modelBuilder.Entity<Core.Domain.Company>()
                .Property(item => item.WorkingHours).HasColumnType("jsonb");



            modelBuilder.Entity<Equipment>().ToTable("Equipments");

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Equipment)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired();
        }
    }
}
