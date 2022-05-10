using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProjectVFront.Crosscutting.Utils;

namespace ProjectVFront.Infrastructure.ExternalServices;
public class WebApiExternalServiceBase
{
    protected readonly IFlurlClient _flurlClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly BaseWebApiOptions _baseWebApiConfiguration;
    public WebApiExternalServiceBase(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor, IOptions<BaseWebApiOptions> options)
    {
        _baseWebApiConfiguration = options.Value;

        _httpContextAccessor = httpContextAccessor;

        var baseUri = new Uri(_baseWebApiConfiguration.BaseUrl);
        var url = baseUri.AppendPathSegment(_baseWebApiConfiguration.ApiVersion);

        _flurlClient = flurlClientFactory.Get(url);

        _flurlClient.BeforeCall(flurlCall =>
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies[HttpConstants.XAccessToken];

            if (!string.IsNullOrWhiteSpace(token))
                flurlCall.HttpRequestMessage.SetHeader("Authorization", $"Bearer {token}");
            else
                flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
        });
    }
}
