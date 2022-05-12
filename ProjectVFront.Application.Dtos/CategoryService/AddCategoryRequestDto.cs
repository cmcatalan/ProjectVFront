using ProjectVFront.Crosscutting.Utils.enums;

namespace ProjectVFront.Crosscutting.Dtos;

public class AddCategoryRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CategoryType Type { get; set; } = CategoryType.Expense;
}

