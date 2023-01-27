using FinManager.Models;
using FinManager.Models.ViewModel;
using FinManager.Services;
using FinManager.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Diagnostics;

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

        public IActionResult Create()
        {
            var doers = _doerService.FindAll();
            var viewModel = new IncomeFormViewModel() { Doers= doers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Income income)

        {
            _incomeService.Insert(income);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _incomeService.FindById(id.Value);

            if (obj == null) { return NotFound(); }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _incomeService.FindById(id.Value);

            if (obj == null) { return NotFound(); }

            List<Doer> doers = _doerService.FindAll();

            IncomeFormViewModel viewModel = new IncomeFormViewModel() { Income = obj, Doers = doers };

            return View(viewModel);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Income income)
        {
            if (id != income.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _incomeService.Update(income);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DBConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _incomeService.FindById(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _incomeService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
