using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TransactionsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> GetAll()
        {
            var transactions = await _db.Transactions
                .OrderByDescending(t => t.Date)
                .Select(t => new TransactionDto(t.Id, t.Amount, t.Date, t.Description, t.CategoryId, t.Category.Name, t.Category.Type))
                .ToListAsync();

            return Ok(transactions);
        }
    }
}
