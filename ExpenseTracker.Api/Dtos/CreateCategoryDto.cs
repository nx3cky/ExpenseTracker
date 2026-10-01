using ExpenseTracker.Api.Entities;

namespace ExpenseTracker.Api.Dtos
{
    public record CreateCategoryDto(string Name, TransactionType Type);
}
