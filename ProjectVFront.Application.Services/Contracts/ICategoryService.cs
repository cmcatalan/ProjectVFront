using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Application.Services;
public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(AddCategoryRequestDto dto);
    Task<CategoryDto> GetCategoryAsync(int categoryId);
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> EditCategoryAsync(EditCategoryRequestDto dto);
    Task<CategoryDto> DeleteCategoryAsync(int categoryId);
}
