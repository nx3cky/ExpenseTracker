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
            var categories = await _db.Categories
                .Select(c => new CategoryDto(c.Id, c.Name, c.Type))
                .ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _db.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto(c.Id, c.Name, c.Type))
                .FirstOrDefaultAsync();

            if (category == null)
            { 
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            Category category = new Category { Name = createCategoryDto.Name, Type = createCategoryDto.Type};

            _db.Categories.Add(category);

            await _db.SaveChangesAsync();

            CategoryDto categoryDto = new CategoryDto(category.Id, category.Name, category.Type);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, categoryDto);
        }

    }
}
