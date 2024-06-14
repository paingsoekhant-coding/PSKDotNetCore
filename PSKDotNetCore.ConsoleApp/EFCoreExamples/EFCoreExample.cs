using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSKDotNetCore.ConsoleApp.Dtos;

namespace PSKDotNetCore.ConsoleApp.EFCoreExamples;

public class EFCoreExample
{
    //private readonly AppDbContext db = new AppDbContext();
    private readonly AppDbContext db;

    public EFCoreExample(AppDbContext db)
    {
        this.db = db;
    }   

    public void Run()
    {
        //Read();
        //Edit(17);
        //Edit(34);
        //Create("New EFcore" , "EFCore Author" , "EFCore Content");
        Update(17, "EFCore Update2", "EFCore Author Update", "EFCore Content Uppdate");
        //Delete(38);
    }

    //EFCore read method
    private void Read()
    {
        var lst = db.Blogs.ToList();
        foreach (BlogDto blog in lst)
        {
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
            Console.WriteLine("----------------------");

        }
    }

    //EFCore edit method
    private void Edit(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
        Console.WriteLine("----------------------");
    }

    //EFCore create method
    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogAuthor = author,
            BlogContent = content,
            BlogTitle = title
        };

        db.Blogs.Add(item);
        int result = db.SaveChanges();

        string message = result > 0 ? "Create Successful." : "Create Failed.";
        Console.WriteLine(message);
    }

    //EFCore update method
    private void Update(int id, string title, string author, string content)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;

        int result = db.SaveChanges();

        string message = result > 0 ? "Update Successful." : "Update Failed.";
        Console.WriteLine(message);

    }

    //EFCore delete method
    private void Delete(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        db.Blogs.Remove(item);
        int result = db.SaveChanges();

        string message = result > 0 ? "Delete Successful." : "Delete Failed.";
        Console.WriteLine(message);

    }
}
