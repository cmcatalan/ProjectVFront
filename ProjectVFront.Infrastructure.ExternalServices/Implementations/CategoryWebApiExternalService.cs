using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Crosscutting.Utils;

namespace ProjectVFront.Infrastructure.ExternalServices;
public class CategoryWebApiExternalService : WebApiExternalServiceBase, ICategoryWebApiExternalService
{
    private readonly CategoriesWebApiOptions _categoriesWebApiOptions;
    public CategoryWebApiExternalService(
        IFlurlClientFactory flurlClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IOptions<BaseWebApiOptions> baseWebApiOptions,
        IOptions<CategoriesWebApiOptions> categoriesWebApiOptions) : base(flurlClientFactory, httpContextAccessor, baseWebApiOptions)
    {
        _categoriesWebApiOptions = categoriesWebApiOptions.Value;
    }

    public async Task<CategoryDto> GetCategoryAsync(int categoryId)
    {
        return await _flurlClient.Request(_categoriesWebApiOptions.CategoriesRoute, _categoriesWebApiOptions.CategoriesGetAction, categoryId)
            .GetJsonAsync<CategoryDto>();
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _flurlClient.Request(_categoriesWebApiOptions.CategoriesRoute, _categoriesWebApiOptions.CategoriesGetAllAction)
            .GetJsonAsync<IEnumerable<CategoryDto>>();
    }

    public async Task<CategoryDto> CreateCategoryAsync(AddCategoryRequestDto dto)
    {
        return await _flurlClient.Request(_categoriesWebApiOptions.CategoriesRoute, _categoriesWebApiOptions.CategoriesAddAction)
            .PostJsonAsync(dto)
            .ReceiveJson<CategoryDto>();
    }

    public async Task<CategoryDto> EditCategoryAsync(EditCategoryRequestDto dto)
    {
        return await _flurlClient.Request(_categoriesWebApiOptions.CategoriesRoute, _categoriesWebApiOptions.CategoriesEditAction)
           .PutJsonAsync(dto)
           .ReceiveJson<CategoryDto>();
    }

    public async Task<CategoryDto> DeleteCategoryAsync(int categoryId)
    {
        return await _flurlClient.Request(_categoriesWebApiOptions.CategoriesRoute, _categoriesWebApiOptions.CategoriesDeleteAction, categoryId)
           .DeleteAsync()
           .ReceiveJson<CategoryDto>();
    }
}
