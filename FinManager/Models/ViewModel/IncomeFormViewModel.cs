namespace FinManager.Models.ViewModel
{
    public class IncomeFormViewModel
    {
        public Income Income { get; set; }
        public ICollection<Doer> Doers { get; set; }
    }
}
