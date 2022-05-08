using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Application.Services;
public interface IUserManagementService
{
    Task<UserDto> SignUpAsync(SignUpRequestDto dto);
    Task<string> LoginAsync(string username, string password);
    Task<UserDto> GetUserInfoAsync(string userId);
    Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto, string id);
}
