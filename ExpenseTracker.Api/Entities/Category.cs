using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }
        public TransactionType Type { get; set; }
    }
}
