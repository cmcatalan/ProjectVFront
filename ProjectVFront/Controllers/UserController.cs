using AutoMapper;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Application.Services;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.WebClient.ViewModels;
using System.Diagnostics;

namespace ProjectVFront.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManagementService _userManagement;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserManagementService userManagement, IMapper mapper)
        {
            _logger = logger;
            _userManagement = userManagement;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("edit");
        }


        [HttpGet]
        [Route("{action}")]
        public async Task<IActionResult> Edit()
        {
            var dto = await _userManagement.GetUserInfoAsync();

            var viewmodel = _mapper.Map<EditUserViewModel>(dto);

            return View(viewmodel);
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<IActionResult> Edit(EditUserViewModel viewmodel)
        {
            try
            {
                var requestDto = _mapper.Map<EditUserRequestDto>(viewmodel);

                var userDto = await _userManagement.UpdateUserInfoAsync(requestDto);

                ModelState.Clear();

                viewmodel = _mapper.Map<EditUserViewModel>(userDto);

                return View(viewmodel);

            }
            catch (FlurlHttpException ex)
            {
                ViewBag.Error = await GetErrorMessageAsync(ex);
            }

            return View(viewmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<string> GetErrorMessageAsync(FlurlHttpException ex)
        {
            if (ex.StatusCode == 400)
            {
                var httpError = await ex.GetResponseJsonAsync<HttpError>();
                return httpError.Message;
            }

            throw ex;
        }
    }
}