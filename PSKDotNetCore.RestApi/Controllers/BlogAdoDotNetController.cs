using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PSKDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace PSKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        //read method
        [HttpGet]
        public IActionResult GetBLogs()
        {
            string query = "select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            //List<BlogModel> lst = new List<BlogModel>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //   BlogModel blog = new BlogModel();
            //   blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //  blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //  blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //  blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            //lst.Add(blog);
            //}

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);
        }

        //edit method
        [HttpGet("{id}")]
        public IActionResult EditBlog(int id) 
        {
            string query = @"select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
           
            connection.Close();

            if(dt.Rows.Count == 0)
            {
                return NotFound("No Data Found");
            }

            DataRow dr = dt.Rows[0];

            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };

            return Ok(item);
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

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery(); 

            connection.Close();

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

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            var item = FindId(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            blog.BlogId = id;

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            //return number of affected rows
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update Successful." : "Update Failed.";

            return Ok(message);
        }

        //update with patch method 
        [HttpPatch("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string conditions = string.Empty;
   
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";

            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";

            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";

            }
            if ( conditions.Length == 0)
            {
                return NotFound("No Data Found To Update.");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            //sql query
            string query = $@"UPDATE [dbo].[tbl_blog] SET{conditions} WHERE BlogID = @BlogID";
           
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogID", id);

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);

            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);

            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            }

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Update Successful With Patch." : "Update Failed With Patch.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            //sql query 
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            //check delete success or fail.
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";

            return Ok(message);
        }
        private BlogModel? FindId(int id)
        {

            string query = "select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }


    }
}
