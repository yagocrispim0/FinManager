namespace FinManager.Models
{
    public class Doer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Income> IncomeList { get; set; }
        public ICollection<Expense> ExpenseList { get; set; }

        public Doer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Doer()
        {
        }

        public void AddIncome(Income income)
        {
            IncomeList.Add(income);
        }

        public void RemoveIncome(int id)
        {
            var obj = IncomeList.FirstOrDefault(x => x.Id == id);
            IncomeList.Remove(obj);
        }
    }
}
