using FinManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinManager.Controllers
{
    public class IncomesController : Controller
    {
        private readonly IncomeService _incomeService;
        private readonly DoerService _doerService;

        public IncomesController(IncomeService incomeService, DoerService doerService)
        {
            _incomeService = incomeService;
            _doerService = doerService;
        }

        public IActionResult Index()
        {
            var list = _incomeService.FindAll();
            return View(list);
        }
    }
}
