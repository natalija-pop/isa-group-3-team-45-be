using ISAProject.Modules.Stakeholders.Core.Mappers;
using ISAProject.Modules.Stakeholders.Core.UseCases;
using ISAProject.Modules.Stakeholders.Infrastructure.Database;
using ISAProject.Modules.Stakeholders.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using ISAProject.Configuration.Infrastructure.Database;
using ISAProject.Modules.Stakeholders.API.Public;
using Microsoft.EntityFrameworkCore;


namespace ISAProject.Modules.Stakeholders.Infrastructure
{
    public static class StakeholderStartup
    {
        public static IServiceCollection ConfigureStakeholdersModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StakeholderProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenGenerator, JwtGenerator>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {

            services.AddDbContext<StakeholdersContext>(opt =>
                opt.UseNpgsql(DatabaseConnectionBuilder.Build("stakeholders"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "stakeholders")));
        }
    }
}
