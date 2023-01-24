using Microsoft.AspNetCore.Mvc;

namespace FinManager.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
