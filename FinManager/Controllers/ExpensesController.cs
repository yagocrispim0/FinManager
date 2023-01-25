using FinManager.Data;
using FinManager.Models;
using FinManager.Models.ViewModel;
using FinManager.Services;
using FinManager.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

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
        [ValidateAntiForgeryToken]
        public IActionResult create(Expense expense)
        {
            _expenseService.Insert(expense);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _expenseService.FindById(id.Value);

            if(obj == null) { return NotFound(); }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _expenseService.FindById(id.Value);

            if(obj == null) { return NotFound();}

            List<Doer> doers= _doerService.FindAll();

            ExpenseFormViewModel viewModel = new ExpenseFormViewModel() { Expense = obj, Doers= doers };

            return View(viewModel);

        }



        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            { 
                _expenseService.Update(expense);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
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
            var obj = _expenseService.FindById(id);
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
            _expenseService.Remove(id);
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
