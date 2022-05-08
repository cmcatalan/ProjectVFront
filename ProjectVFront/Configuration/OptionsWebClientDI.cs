using ProjectVFront.Crosscutting.Utils;

namespace ProjectVFront.Configuration
{
    public static class OptionsWebClientDI
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthWebApiOptions>(configuration.GetSection(AuthWebApiOptions.SectionName));
            services.Configure<BaseWebApiOptions>(configuration.GetSection(BaseWebApiOptions.SectionName));
            services.Configure<CategoriesWebApiOptions>(configuration.GetSection(CategoriesWebApiOptions.SectionName));
            services.Configure<TransactionsWebApiOptions>(configuration.GetSection(TransactionsWebApiOptions.SectionName));
            services.Configure<UsersWebApiOptions>(configuration.GetSection(UsersWebApiOptions.SectionName));

            return services;
        }
    }

}
