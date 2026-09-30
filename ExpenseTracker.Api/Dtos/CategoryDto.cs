using ExpenseTracker.Api.Entities;

namespace ExpenseTracker.Api.Dtos
{
    public record CategoryDto(int Id, string Name, TransactionType Type);
}
