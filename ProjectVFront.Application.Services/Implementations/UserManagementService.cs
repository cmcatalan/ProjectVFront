using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Infrastructure.ExternalServices;

namespace ProjectVFront.Application.Services;
public class UserManagementService : IUserManagementService
{
    private readonly IUserManagementWebApiExternalService _userManagementExternal;
    public UserManagementService(IUserManagementWebApiExternalService userManagementExternal)
    {
        _userManagementExternal = userManagementExternal;
    }

    public async Task<UserDto> GetUserInfoAsync()
    {
        return await _userManagementExternal.GetUserInfoAsync();
    }

    public async Task<string> LoginAsync(LogInRequestDto dto)
    {
        return await _userManagementExternal.LoginAsync(dto);
    }

    public async Task<UserDto> SignUpAsync(SignUpRequestDto dto)
    {
        return await _userManagementExternal.SignUpAsync(dto);
    }

    public async Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto)
    {
        return await _userManagementExternal.UpdateUserInfoAsync(dto);
    }
}
