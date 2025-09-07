
using BlogApi.Data;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Controllers
{

    [Route("api/[controller]")]
          [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppdbContext _context;
        public BlogController(AppdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var blog = _context.blogs.ToList();
            return Ok(blog);
        }
        [HttpPost]
        public IActionResult AddGetBlog(Blog blog)
        {
            _context.blogs.Add(blog);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBlog(int id, Blog blog)
        {
            var blogupdate = _context.blogs.Find(id);
            blogupdate.Title = blog.Title;
            blogupdate.Content = blog.Content;
            blogupdate.Category = blog.Category;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeletedBlog(int id)
        {
            var values = _context.blogs.Find(id);
            _context.blogs.Remove(values);
            _context.SaveChanges();
            return Ok();

        }
    }
}