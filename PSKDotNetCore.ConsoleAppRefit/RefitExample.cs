using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKDotNetCore.ConsoleAppRefit;

public class RefitExample
{
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7147");
    public async Task RunAsync()
    {
        //await ReadAsync();
        await EditAsync(54);
        //await EditAsync(180);
        //await CreateAsync("RefitT", "RefitA", "RefitC");
        //await UpdateAsync(54,"RefitU","RefitU", "RefitU");
        //await DeleteAsync(54);
    }

    private async Task ReadAsync()
    {
     
        var lst = await _service.GetBlogs();
        foreach (var blog in lst)
        {
            Console.WriteLine($"Id => {blog.BlogId}");
            Console.WriteLine($"Title => {blog.BlogTitle}");
            Console.WriteLine($"Author => {blog.BlogAuthor}");
            Console.WriteLine($"Content => {blog.BlogContent}");
            Console.WriteLine("_________________________________");
        }
    }

    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);
            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("_________________________________");
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,
        };

        var message = await _service.CreateBlog(blog);
        Console.WriteLine(message);
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,
        };

        var message = await _service.UpdateBlog(id, blog);
        Console.WriteLine(message);
    }

    private async Task DeleteAsync(int id)
    {
        var message = await _service.DeleteBlog(id);
        Console.WriteLine(message);
    }
}
