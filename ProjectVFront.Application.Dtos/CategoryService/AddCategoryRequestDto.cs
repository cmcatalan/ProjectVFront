using ProjectVFront.Crosscutting.Utils.enums;

namespace ProjectVFront.Crosscutting.Dtos;
public record AddCategoryRequestDto(string Name, string PictureUrl, string Description, CategoryType Type);

