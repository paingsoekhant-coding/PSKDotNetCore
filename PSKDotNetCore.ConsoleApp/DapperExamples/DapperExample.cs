using Dapper;
using PSKDotNetCore.ConsoleApp.Dtos;
using PSKDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PSKDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {

        public void Run()
        {
            //Create("test2 title", "test2 author", "test2 content");
            //Read();
            //Edit(36);
            //Edit(34);
            //Update(36, "update title" , "update author" , "update content");
            Delete(36);

        }

        //dapper read method
        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            List<BlogDto> lst = db.Query<BlogDto>("select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog").ToList();

            foreach (BlogDto blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("----------------------");

            }


        }

        //dapper edit method 
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            //old verison 
            //if(item == null)
            //new version 
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

        //dapper create method 
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogAuthor = author,
                BlogContent = content,
                BlogTitle = title
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Create Successful." : "Create Failed.";
            Console.WriteLine(message);

        }

        //dapper update method
        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            //sql query 
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);

        }

        //dapper delete method 
        private void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id
            };
            //sql delete query 
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);
        }

    }
}
