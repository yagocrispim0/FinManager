using FinManager.Data;
using FinManager.Models;

namespace FinManager.Services.Exceptions
{
    public class DepartmentService
    {
        private readonly FinManagerContext _context;

        public DepartmentService(FinManagerContext context)
        {
            _context = context;
        }

        public List<Doer> FindAll()
        {
            return _context.Doer.OrderBy(d => d.Name).ToList();
        }
    }
}