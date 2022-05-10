using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Application.Services;
public interface IUserManagementService
{
    Task<UserDto> SignUpAsync(SignUpRequestDto dto);
    Task<string> LoginAsync(LogInRequestDto dto);
    Task<UserDto> GetUserInfoAsync();
    Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto);
}
