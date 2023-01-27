using FinManager.Data;
using FinManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinManager.Services
{
    public class IncomeService
    {
        private readonly FinManagerContext _context;

        public IncomeService(FinManagerContext context)
        {
            _context = context;
        }

        public List<Income> FindAll()
        {
            return _context.Income.Include(obj => obj.Doer).OrderBy(x => x.Date).ToList();
        }

        public void Insert(Income income)
        {
            _context.Add(income);
            _context.SaveChanges();
        }

        public Income FindById(int? id)
        {
            return _context.Income.Include(obj => obj.Doer).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int? id)
        {
            var obj = _context.Income.Find(id);
            _context.Income.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Income obj)
        {
            if (!_context.Income.Any(x => x.Id == obj.Id))
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
