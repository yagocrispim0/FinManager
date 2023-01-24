using FinManager.Data;
using FinManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinManager.Services
{
    public class ExpenseService
    {
        private readonly FinManagerContext _context;

        public ExpenseService(FinManagerContext context)
        {
            _context = context;
        }

        public List<Expense> FindAll()
        {
            return _context.Expense.OrderBy(x => x.Date).ToList();       
        }

        public void Insert(Expense expense)
        {
            _context.Add(expense);
            _context.SaveChanges();
        }

        public Expense FindById(int id)
        {
            return _context.Expense.Include(obj => obj.Doer).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Expense.Find(id);
            _context.Expense.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Expense obj)
        {
            if (!_context.Expense.Any(x => x.Id == obj.Id))
            {
                throw new Exception("Id not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
