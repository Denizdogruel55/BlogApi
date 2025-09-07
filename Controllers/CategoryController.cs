using BlogApi.Data;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppdbContext _context;
    public CategoryController(AppdbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var values = _context.categories.ToList();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        _context.categories.Add(category);
        _context.SaveChanges();
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateCategory(Category category, int id)
    {
        var values = _context.categories.Find(id);
        values.Name = category.Name;
        _context.SaveChanges();
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteCategory(int id, Category category)
    {
        var valuesdelete = _context.categories.Find(id);
        _context.categories.Remove(valuesdelete);
        _context.SaveChanges();
        return Ok();
    }
}
