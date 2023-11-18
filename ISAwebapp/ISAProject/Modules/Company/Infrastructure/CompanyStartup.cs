using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Mappers;
using ISAProject.Modules.Company.Core.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISAProject.Configuration.Infrastructure.Database;
using ISAProject.Modules.Company.Infrastructure.Database;

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
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Core.Domain.Company>), typeof(CrudRepository<Core.Domain.Company, CompanyContext>));

            services.AddDbContext<CompanyContext>(opt =>
                opt.UseNpgsql(DatabaseConnectionBuilder.Build("company")));
        }
    }
}
