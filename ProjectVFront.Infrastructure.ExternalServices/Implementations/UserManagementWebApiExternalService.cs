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
    public async Task<UserDto> GetUserInfoAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> SignUpAsync(SignUpRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto, string id)
    {
        throw new NotImplementedException();
    }
}
