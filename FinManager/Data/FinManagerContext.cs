using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinManager.Models;

namespace FinManager.Data
{
    public class FinManagerContext : DbContext
    {
        public FinManagerContext (DbContextOptions<FinManagerContext> options)
            : base(options)
        {
        }

        public DbSet<FinManager.Models.Doer> Doer { get; set; } = default!;
        public DbSet<FinManager.Models.Expense> Expense { get; set; }
        public DbSet<FinManager.Models.Income> Income { get; set; }
    }
}
