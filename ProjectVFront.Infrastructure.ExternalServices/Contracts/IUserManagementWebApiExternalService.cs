using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Infrastructure.ExternalServices;
public interface IUserManagementWebApiExternalService
{
    Task<UserDto> SignUpAsync(SignUpRequestDto dto);
    Task<string> LoginAsync(LogInRequestDto dto);
    Task<UserDto> GetUserInfoAsync();
    Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto);
}
