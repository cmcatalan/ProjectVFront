using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Infrastructure.ExternalServices;

namespace ProjectVFront.Application.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryWebApiExternalService _categoryExternalService;
    public CategoryService(ICategoryWebApiExternalService categoryExternalService)
    {
        _categoryExternalService = categoryExternalService;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _categoryExternalService.GetAllCategoriesAsync();
    }

    public async Task<CategoryDto> GetCategoryAsync(int categoryId)
    {
        return await _categoryExternalService.GetCategoryAsync(categoryId);
    }
    public async Task<CategoryDto> CreateCategoryAsync(AddCategoryRequestDto dto)
    {
        return await _categoryExternalService.CreateCategoryAsync(dto);
    }

    public async Task<CategoryDto> EditCategoryAsync(EditCategoryRequestDto dto)
    {
        return await _categoryExternalService.EditCategoryAsync(dto);
    }

    public async Task<CategoryDto> DeleteCategoryAsync(int categoryId)
    {
        return await _categoryExternalService.DeleteCategoryAsync(categoryId);
    }
}
