using ExpenseTracker.Api.Entities;

namespace ExpenseTracker.Api.Dtos
{
    public record UpdateCategoryDto(string Name, TransactionType Type);
}
