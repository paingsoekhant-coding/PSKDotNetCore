using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PSKDotNetCore.RestApi.Db;
using PSKDotNetCore.RestApi.Models;

namespace PSKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context = new AppDbContext();
        //get method 
        [HttpGet]
        public IActionResult Read()
        {
           var lst =  _context.Blogs.ToList();
            return Ok(lst);
        }
        //edit method 
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if(item is null)
            {
               return NotFound("No Data Found.");
                
            }
           
            return Ok(item);
        }
        //post method
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Create Successful." : "Create Failed.";
            return Ok(message);
        }
        //put method 
        [HttpPut("{id}")]
        public IActionResult Update(int id , BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found.");

            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();

            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
        }
        //patch method
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogTitle = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogTitle = blog.BlogContent;
            }

            
            var result = _context.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
        }
        //delete method
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);
        }
    }
}
