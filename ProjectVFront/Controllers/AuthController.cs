using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Models;
using ProjectVFront.Models.Api;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProjectVFront.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Login();
        }

        [HttpGet]
        [Route("{action}")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("{action}")]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [Route("{action}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            //todo validations

            var toSend = new
            {
                userName = request.UserName,
                firstName = request.FirstName,
                lastName = request.LastName,
                email = request.Email,
                password = request.Password
            };

            try
            {
                string json = JsonSerializer.Serialize(toSend);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient()) //todo factory httpclient
                {

                    //client.BaseAddress = new Uri("https://localhost:7162/");

                    var response = await client.PostAsync("https://localhost:7162/api/auth/signup", data);
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error post to backend", ex);
            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}