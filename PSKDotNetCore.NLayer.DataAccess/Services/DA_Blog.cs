﻿using PSKDotNetCore.NLayer.DataAccess.Db;

namespace PSKDotNetCore.NLayer.DataAccess.Services;

public class DA_Blog
{
    //Data Access
    private readonly AppDbContext _context;

    public DA_Blog()
    {
        _context = new AppDbContext();
    }

    public List<BlogModel> GetBlogs()
    {
        var lst = _context.Blogs.ToList();
        return lst;
    }

    public BlogModel GetBlog(int id)
    {
        var result = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        return result;
    }

    public int CreateBlog(BlogModel requestModel)
    {
        _context.Blogs.Add(requestModel);
        var result = _context.SaveChanges();
        return result;
    }

    public int UpdateBlog(int id, BlogModel requestModel)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null) return 0;

        item.BlogTitle = requestModel.BlogTitle;
        item.BlogAuthor = requestModel.BlogAuthor;
        item.BlogContent = requestModel.BlogContent;

        var result = _context.SaveChanges();
        return result;
    }

    public int DeleteBlog(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null) return 0;

        _context.Blogs.Remove(item);
        var result = _context.SaveChanges();
        return result;
    }
}
