using FinManager.Data;
using FinManager.Models;

namespace FinManager.Services
{
    public class DoerService
    {
        private readonly FinManagerContext _context;

        public DoerService(FinManagerContext context)
        {
            _context = context;
        }

        public List<Doer> FindAll()
        {
            return _context.Doer.OrderBy(x => x.Id).ToList();
        }

        public void Insert(Doer doer)
        {
            _context.Add(doer);
            _context.SaveChanges();
        }
    }
}
