namespace FinManager.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Doer Doer { get; set; }

    }
}
