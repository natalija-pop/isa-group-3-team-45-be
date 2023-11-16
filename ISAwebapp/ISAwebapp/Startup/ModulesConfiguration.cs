using ISAProject.Modules.Company.Infrastructure;
using ISAProject.Modules.Stakeholders.Infrastructure;

namespace API.Startup
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services.ConfigureStakeholdersModule();
            services.ConfigureCompanyModule();
            return services;
        }
    }
}
