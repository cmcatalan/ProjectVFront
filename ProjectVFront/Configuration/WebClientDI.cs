using ProjectVFront.Application.Services;

namespace ProjectVFront.Configuration
{
    public static class WebClientDI
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();

            return services;
        }
    }

}
