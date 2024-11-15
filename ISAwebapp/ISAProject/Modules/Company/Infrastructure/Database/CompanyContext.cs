﻿using ISAProject.Modules.Company.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Company.Infrastructure.Database
{
    public class CompanyContext: DbContext
    {
        public DbSet<Core.Domain.Company> Companies { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("companies");


            modelBuilder.Entity<Core.Domain.Company>().ToTable("Companies");
            modelBuilder.Entity<Core.Domain.Company>()
                .HasMany(e => e.WorkCalendar);

            modelBuilder.Entity<Core.Domain.Company>()
                .Property(item => item.Address).HasColumnType("jsonb");
            modelBuilder.Entity<Core.Domain.Company>()
                .Property(item => item.WorkingHours).HasColumnType("jsonb");


            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Equipment)
                .WithMany();


            modelBuilder.Entity<Equipment>().ToTable("Equipments");
        }
    }
}
