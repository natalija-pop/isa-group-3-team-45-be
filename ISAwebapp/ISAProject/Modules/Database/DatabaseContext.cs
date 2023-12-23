using ISAProject.Modules.Company.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Database
{
    public class DatabaseContext: DbContext
    {

        public DbSet<Company.Core.Domain.Company> Companies { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("isa");

            modelBuilder.Entity<Company.Core.Domain.Company>().ToTable("Companies");
            modelBuilder.Entity<Company.Core.Domain.Company>()
                .HasMany(e => e.WorkCalendar);

            modelBuilder.Entity<Company.Core.Domain.Company>()
                .HasMany(e => e.Equipment)
                .WithOne()
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company.Core.Domain.Company>()
                .Property(item => item.Address).HasColumnType("jsonb");
            modelBuilder.Entity<Company.Core.Domain.Company>()
                .Property(item => item.WorkingHours).HasColumnType("jsonb");


            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Equipment)
                .WithMany();


            modelBuilder.Entity<Equipment>().ToTable("Equipments");
        }
    }
}
