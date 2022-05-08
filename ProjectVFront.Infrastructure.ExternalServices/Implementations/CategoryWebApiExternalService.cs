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

    public async Task<CategoryDto> CreateCategoryAsync(AddCategoryRequestDto dto, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDto> DeleteCategoryAsync(int categoryId, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDto> EditCategoryAsync(EditCategoryRequestDto dto, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDto> GetCategoryAsync(int categoryId, string userId)
    {
        throw new NotImplementedException();
    }
}
