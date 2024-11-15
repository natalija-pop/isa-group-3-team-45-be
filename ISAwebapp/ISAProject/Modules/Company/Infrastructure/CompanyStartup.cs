﻿using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Mappers;
using ISAProject.Modules.Company.Core.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISAProject.Configuration.Infrastructure.Database;
using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Company.Infrastructure.Database.Repositories;
using ISAProject.Modules.Database;

namespace ISAProject.Modules.Company.Infrastructure
{
    public static class CompanyStartup
    {
        public static IServiceCollection ConfigureCompanyModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CompanyProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IQrCodeReaderService, QrCodeReaderService>();
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Core.Domain.Company>), typeof(CrudRepository<Core.Domain.Company, DatabaseContext>));
            services.AddScoped(typeof(ICrudRepository<Equipment>), typeof(CrudRepository<Equipment, DatabaseContext>));
            services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));

            services.AddDbContext<DatabaseContext>(opt =>
                opt.UseNpgsql(DatabaseConnectionBuilder.Build("isa"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "isa")));
        }
    }
}