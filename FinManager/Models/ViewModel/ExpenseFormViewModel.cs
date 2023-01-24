namespace FinManager.Models.ViewModel
{
    public class ExpenseFormViewModel
    {
        public Expense Expense { get; set; }
        public ICollection<Doer> Doers { get; set; }
    }
}
