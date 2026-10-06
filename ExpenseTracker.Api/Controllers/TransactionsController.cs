using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Entities;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransactionDto>> GetById(int id)
        {
            var transaction = await _db.Transactions
                .Where(t => t.Id == id)
                .Select(t => new TransactionDto(t.Id, t.Amount, t.Date, t.Description, t.CategoryId, t.Category.Name, t.Category.Type))
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create([FromBody] CreateTransactionDto dto)
        {
            var category = await _db.Categories.FindAsync(dto.CategoryId);

            if (category == null)
            {
                ModelState.AddModelError(nameof(dto.CategoryId), "Category not found.");
                return ValidationProblem(ModelState);
            }

            Transaction transaction = new Transaction { Amount = dto.Amount, Date = dto.Date.Value, Description = dto.Description, CategoryId = category.Id };
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();

            TransactionDto transactionDto = new TransactionDto(transaction.Id, transaction.Amount,
                transaction.Date, transaction.Description, transaction.CategoryId, category.Name, category.Type);

            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transactionDto);  
        }
    }
}
