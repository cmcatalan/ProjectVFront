using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Application.Services;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.WebClient.ViewModels;
using System.Diagnostics;

namespace ProjectVFront.Controllers
{
    [Authorize]
    public class SummaryController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public SummaryController(ILogger<AuthController> logger, ITransactionService transactionService, IMapper mapper)
        {
            _logger = logger;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index([FromQuery] int? year, int? month)
        {
            var now = DateTime.Now;
            var from = new DateTime(year ?? now.Year, month ?? now.Month, 1);
            var lastDayOfMonth = from.AddMonths(1).AddDays(-1);
            var to = new DateTime(lastDayOfMonth.Year, lastDayOfMonth.Month, lastDayOfMonth.Day, 23, 59, 59);

            var defaultRequest = new GetTransactionsSummaryRequestDto(from, to);
            var summary = await _transactionService.GetSummary(defaultRequest);

            ViewBag.Month = from.ToString("MMMM");  
            ViewBag.Summary = new
            {
                incomes = summary.Incomes.ToString("0.00"),
                expenses = summary.Expenses.ToString("0.00"),
                total = summary.Total.ToString("0.00"),
            };

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}