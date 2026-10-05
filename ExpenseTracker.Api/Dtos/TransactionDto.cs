using ExpenseTracker.Api.Entities;

namespace ExpenseTracker.Api.Dtos
{
    public record TransactionDto(int Id, decimal Amount, DateOnly Date, string? Description, int CategoryId, string CategoryName, TransactionType Type);
}
