using FinManager.Models;
using FinManager.Models.ViewModel;
using FinManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinManager.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseService _expenseService;
        private readonly DoerService _doerService;

        public ExpensesController(ExpenseService expenseService, DoerService doerService)
        {
            _expenseService = expenseService;
            _doerService = doerService;
        }


        public IActionResult Index()
        {
            var list = _expenseService.FindAll();
            return View(list);
        }

        //Get
        public IActionResult create()
        {

            var doers = _doerService.FindAll();
            var viewModel = new ExpenseFormViewModel { Doers= doers };
            return View(viewModel);
        }

        //Post
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult create(Expense expense)
        {
            _expenseService.Insert(expense);
            return RedirectToAction(nameof(Index));
        }

    }
}
