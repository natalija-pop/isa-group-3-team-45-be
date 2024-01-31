using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Infrastructure.Database
{
    public class ContractContext : DbContext
    {
        public DbSet<HospitalContract> Contracts { get; set; }

        public ContractContext(DbContextOptions<ContractContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("hospital");

            modelBuilder.Entity<HospitalContract>()
                .ToTable("Contracts")
                .HasKey(c => c.Id);
        }
    }
}
