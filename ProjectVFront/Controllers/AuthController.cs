using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Application.Services;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Crosscutting.Utils;
using ProjectVFront.WebClient.ViewModels;
using System.Diagnostics;

namespace ProjectVFront.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserManagementService _userManagement;
        private readonly IMapper _mapper;

        public AuthController(ILogger<AuthController> logger, IUserManagementService userManagement, IMapper mapper)
        {
            _logger = logger;
            _userManagement = userManagement;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return Login();
        }

        [HttpGet]
        [Route("{action}")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Summary");

            return View();
        }


        [HttpPost]
        [Route("{action}")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel request)
        {
            var dto = _mapper.Map<LogInRequestDto>(request);

            var tokenResponse = await _userManagement.LoginAsync(dto);

            var cookieOptions = new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict };

            Response.Cookies.Append(HttpConstants.XAccessToken, tokenResponse, cookieOptions);

            return RedirectToAction("Index", "Summary");
        }

        [HttpGet]
        [Route("{action}")]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Summary");

            return View();
        }


        [HttpPost]
        [Route("{action}")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            var dto = _mapper.Map<SignUpRequestDto>(request);
            var user = await _userManagement.SignUpAsync(dto);

            if (user == null)
                throw new Exception();

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Route("{action}")]
        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Append(HttpConstants.XAccessToken, string.Empty);

            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}