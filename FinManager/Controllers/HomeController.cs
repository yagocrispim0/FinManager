using FinManager.Models;
using FinManager.Models.ViewModel;
using FinManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IncomeService _incomeService;
        private readonly ExpenseService _expenseService;

        public HomeController(ILogger<HomeController> logger, ExpenseService expenseService, IncomeService incomeService)
        {
            _logger = logger;
            _expenseService = expenseService;
            _incomeService = incomeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult History()
        {
            var incomes = _incomeService.FindAll();
            var expenses = _expenseService.FindAll();
            var viewModel = new HistoryViewModel() { Expenses= expenses,Incomes= incomes};
            return View(viewModel);
        }
    }
}