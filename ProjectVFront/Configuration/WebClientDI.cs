using ProjectVFront.Application.Services;

namespace ProjectVFront.Configuration
{
    public static class WebClientDI
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserManagementService, IUserManagementService>();
            services.AddTransient<ICategoryService, ICategoryService>();
            services.AddTransient<ITransactionService, ITransactionService>();

            return services;
        }
    }

}
