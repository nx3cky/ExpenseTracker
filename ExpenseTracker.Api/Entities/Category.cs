namespace ExpenseTracker.Api.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public TransactionType Type { get; set; }
    }
}
