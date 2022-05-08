using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Infrastructure.ExternalServices;
public interface IUserManagementWebApiExternalService
{
    Task<UserDto> SignUpAsync(SignUpRequestDto dto);
    Task<string> LoginAsync(string username, string password);
    Task<UserDto> GetUserInfoAsync(string userId);
    Task<UserDto> UpdateUserInfoAsync(EditUserRequestDto dto, string id);
}
