using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PSKDotNetCore.RestApi.Models;
using PSKDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;

namespace PSKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        //private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNet2Controller(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        //read method
        [HttpGet]
        public IActionResult GetBLogs()
        {
            string query = "select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog";

            //from adoDotNetService 
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        //edit method
        [HttpGet("{id}")]
        public IActionResult EditBlog(int id) 
        {
            //string query = @"select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId";

            //from adoDotNetService 
            //var lst = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query,new AdoDotNetParameter("@BlogId", id));
            var lst = FindId(id);

            if (lst is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(lst);
        }

        //create method
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog) 
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                 new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                  new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

            string message = result > 0 ? "Create Successful." : "Create Failed.";
            return Ok(message);
        }

        //update with put method
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id ,BlogModel blog) 
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";

            //from adodonet service
            int result = _adoDotNetService.Execute(query,
                 new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                 new AdoDotNetParameter("@BlogContent", blog.BlogContent)
               );

            //return number of affected rows
            //int result = cmd.ExecuteNonQuery();

            //connection.Close();

            string message = result > 0 ? "Update Successful." : "Update Failed.";

            return Ok(message);
        }

        //update with patch method 
        [HttpPatch("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            List<AdoDotNetParameter> datas = new List<AdoDotNetParameter>();
           
            string conditions = string.Empty;
   
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
                datas.Add(new AdoDotNetParameter("@BlogTitle",blog.BlogTitle));

            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
                datas.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogAuthor));

            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
                datas.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogContent));

            }
            if ( conditions.Length == 0)
            {
                return NotFound("No Data Found To Update.");
            }

            datas.Add(new AdoDotNetParameter("@BlogId", id));
            conditions = conditions.Substring(0, conditions.Length - 2);
            //sql query
            string query = $@"UPDATE [dbo].[tbl_blog] SET{conditions} WHERE BlogID = @BlogID";
           
            int result = _adoDotNetService.Execute(query , datas.ToArray());
            string message = result > 0 ? "Update Successful With Patch." : "Update Failed With Patch.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            //sql query 
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            //check delete success or fail.
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";

            return Ok(message);
        }
        private BlogModel? FindId(int id)
        {

            string query = "select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            return item;
        }


    }
}
