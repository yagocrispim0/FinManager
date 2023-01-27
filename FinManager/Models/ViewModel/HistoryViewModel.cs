namespace FinManager.Models.ViewModel
{
    public class HistoryViewModel
    {
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
