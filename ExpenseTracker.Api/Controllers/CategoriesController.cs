using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories =  await _db.Categories
                .Select(c => new CategoryDto(c.Id, c.Name, c.Type))
                .ToListAsync();
            return Ok(categories);
        }
    }
}
