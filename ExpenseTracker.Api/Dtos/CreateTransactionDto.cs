using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Dtos
{
    public record CreateTransactionDto([Range(typeof(decimal), "0.01", "10000000")] decimal Amount, [Required] DateOnly? Date, [MaxLength(500)] string? Description, [Range(1, int.MaxValue)] int CategoryId);
}