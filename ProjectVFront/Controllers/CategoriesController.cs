using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Application.Services;
using ProjectVFront.WebClient.ViewModels;
using System.Diagnostics;

namespace ProjectVFront.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoryListDto = await _categoryService.GetAllCategoriesAsync();
            var viewmodel = new CategoriesViewModel() { Categories = categoryListDto };

            ModelState.Clear();

            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoriesViewModel viewmodel)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(viewmodel.AddCategoryRequestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriesViewModel viewmodel)
        {
            await _categoryService.EditCategoryAsync(viewmodel.EditCategoryRequestDto);

            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}