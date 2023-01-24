using FinManager.Models;

namespace FinManager.Data
{
    public class SeedingService
    {
        private FinManagerContext _context;

        public SeedingService(FinManagerContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            if(_context.Doer.Any())
            {
                return; //DB has been seeded
            }

            Doer d1 = new Doer(1, "Maria");
            Doer d2 = new Doer(2, "José");



            _context.Doer.AddRange(d1, d2);
            _context.SaveChanges();
        }
    }
}
