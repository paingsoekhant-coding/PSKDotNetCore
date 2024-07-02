using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSKDotNetCore.MvcApp_2_.Db;
using PSKDotNetCore.MvcApp_2_.Models;


namespace PSKDotNetCore.MvcApp_2_.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    public BlogController(AppDbContext db)
    {
        _db = db;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex()
    {
        var lst = await _db.Blogs
            .AsNoTracking()
            .OrderByDescending(x => x.BlogId)
            .ToListAsync();
        return View("BlogIndex",lst);
    }

    [ActionName("Create")]
    public IActionResult BlogCreate()
    {

        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> BlogCreate(BlogModel blog)
    {
        await _db.Blogs.AddAsync(blog);
        var result = await _db.SaveChangesAsync();
        var message = new MessageModel()
        {
            IsSuccess = result > 0 ,
            Message = result > 0 ? "Saving Successful" : "Saving Failed."
        };
        return Json(message);
        //return Redirect("/Blog");
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }
        return View("BlogEdit", item);
    }


    [HttpPost]
    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
    {
        var item = await _db.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _db.Entry(item).State = EntityState.Modified;

        var result = await _db.SaveChangesAsync();
        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Update Successful" : "Update Failed."
        };
        return Json(message);
        //return Redirect("/Blog");
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(BlogModel blog)
    {
        var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        _db.Blogs.Remove(item);
        var result = await _db.SaveChangesAsync();
        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Delete Successful" : "Delete Failed."
        };
        return Json(message);

        //return Redirect("/Blog");
    }
}
