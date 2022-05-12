using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.WebClient.ViewModels;
public class CategoriesViewModel
{
    public IEnumerable<CategoryDto> Categories { get; set; }
    public AddCategoryRequestDto AddCategoryRequestDto { get; set; } = new AddCategoryRequestDto();
    public EditCategoryRequestDto EditCategoryRequestDto { get; set; }
}
