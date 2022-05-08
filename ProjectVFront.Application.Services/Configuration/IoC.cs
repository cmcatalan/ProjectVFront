using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectVFront.Infrastructure.ExternalServices;

namespace ProjectVFront.Application.Services.Configuration;
public static class IoC
{
    public static IServiceCollection AddExternalDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GlobalAppAutomapperProfile));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

        services.AddTransient<ICategoryWebApiExternalService, CategoryWebApiExternalService>();
        services.AddTransient<ITransactionWebApiExternalService, TransactionWebApiExternalService>();
        services.AddTransient<ICategoryWebApiExternalService, CategoryWebApiExternalService>();

        return services;
    }
}
