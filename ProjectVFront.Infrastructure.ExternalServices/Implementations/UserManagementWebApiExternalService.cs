using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Crosscutting.Utils;

namespace ProjectVFront.Infrastructure.ExternalServices;
public class UserManagementWebApiExternalService : WebApiExternalServiceBase, IUserManagementWebApiExternalService
{
    private readonly UsersWebApiOptions _usersWebApiOptions;
    private readonly AuthWebApiOptions _authWebApiOptions;

    public UserManagementWebApiExternalService(
        IFlurlClientFactory flurlClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IOptions<BaseWebApiOptions> baseWebApiOptions,
        IOptions<UsersWebApiOptions> userWebApiOptions,
        IOptions<AuthWebApiOptions> authWebApiOptions) : base(flurlClientFactory, httpContextAccessor, baseWebApiOptions)
    {
        _usersWebApiOptions = userWebApiOptions.Value;
        _authWebApiOptions = authWebApiOptions.Value;
    }

    public async Task<string> LoginAsync(LogInRequestDto dto)
    {
        var response = await _flurlClient.Request(_authWebApiOptions.AuthRoute, _authWebApiOptions.AuthLoginAction)
                        .PostJsonAsync(dto)
                        .ReceiveJson<LoginResponseDto>();

        return response.AccessToken;
    }

    public async Task<UserDto> SignUpAsync(SignUpRequestDto dto)
    {
        return await _flurlClient.Request(_authWebApiOptions.AuthRoute, _authWebApiOptions.AuthSignupAction)
            .PostJsonAsync(dto)
            .ReceiveJson<UserDto>();
    }

    public async Task<UserDto> GetUserInfoAsync()
    {
        return await _flurlClient.Request(_usersWebApiOptions.UsersRoute, _usersWebApiOptions.UsersGetUserInfoAction)
            .GetJsonAsync<UserDto>();
    }

    public async Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto)
    {
        return await _flurlClient.Request(_usersWebApiOptions.UsersRoute, _usersWebApiOptions.UsersUpdateUserInfoAction)
            .PutJsonAsync(dto)
            .ReceiveJson<UserDto>();
    }
}
