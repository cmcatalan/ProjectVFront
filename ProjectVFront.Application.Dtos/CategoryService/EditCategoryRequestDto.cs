using ProjectVFront.Crosscutting.Utils.enums;

namespace ProjectVFront.Crosscutting.Dtos;
public record EditCategoryRequestDto(string Name, string PictureUrl, string Description, CategoryType Type, int Id);

