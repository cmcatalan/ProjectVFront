using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Infrastructure.ExternalServices;
public interface ICategoryWebApiExternalService
{
    Task<CategoryDto> CreateCategoryAsync(AddCategoryRequestDto dto, string userId);
    Task<CategoryDto> GetCategoryAsync(int categoryId, string userId);
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userId);
    Task<CategoryDto> EditCategoryAsync(EditCategoryRequestDto dto, string userId);
    Task<CategoryDto> DeleteCategoryAsync(int categoryId, string userId);
}
