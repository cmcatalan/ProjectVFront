using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVFront.Application.Services;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.WebClient.ViewModels;
using System.Diagnostics;

namespace ProjectVFront.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IFormatProvider _formatProvider;

        public TransactionsController(
            ILogger<TransactionsController> logger,
            ITransactionService transactionService,
            IFormatProvider formatProvider)
        {
            _logger = logger;
            _transactionService = transactionService;
            _formatProvider = formatProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int? year, int? month)
        {
            var viewmodel = new TransactionsViewModel(_formatProvider);

            try
            {
                var now = DateTime.Now;
                var from = new DateTime(year ?? now.Year, month ?? now.Month, 1);
                var lastDayOfMonth = from.AddMonths(1).AddDays(-1);
                var to = new DateTime(lastDayOfMonth.Year, lastDayOfMonth.Month, lastDayOfMonth.Day, 23, 59, 59);
                var transactionsRequest = new GetTransactionsRequestDto(from, to, null);
                var transactionsListDto = await _transactionService.GetAllTransactionsWithCategoryInfo(transactionsRequest);
                viewmodel.Transactions = transactionsListDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            ModelState.Clear();

            return View(viewmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}