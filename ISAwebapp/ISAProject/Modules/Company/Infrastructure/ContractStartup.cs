using ISAProject.Configuration.Core.UseCases;
using ISAProject.Configuration.Infrastructure.Database;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Mappers;
using ISAProject.Modules.Company.Core.UseCases;
using ISAProject.Modules.Company.Infrastructure.Database.Repositories;
using ISAProject.Modules.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISAProject.Modules.Company.Infrastructure.Database;

namespace ISAProject.Modules.Company.Infrastructure
{
    public static class ContractStartup
    {
        public static IServiceCollection ConfigureContractModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ContractProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped(typeof(IContractRepository), typeof(ContractRepository));

            services.AddDbContext<ContractContext>(opt =>
                opt.UseNpgsql(DatabaseConnectionBuilder.Build("hospital"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "hospital")));
        }
    }
}
