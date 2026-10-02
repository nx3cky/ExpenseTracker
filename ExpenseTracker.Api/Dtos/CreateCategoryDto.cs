using ExpenseTracker.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Dtos
{
    public record CreateCategoryDto([Required] [MaxLength(100)] string Name, [EnumDataType(typeof(TransactionType)) ] TransactionType Type);
}
