using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PSKDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        //SqlConnectionStringBuilder method and _ use for global variable
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-5V2KGHB", //server name 
            InitialCatalog = "DotNetTrainingBatch4", //database name
            UserID = "sa",
            Password = "sasa@1234"

        };

        //read method 
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection close.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id =>" + dr["BlogId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("------------------------------------");
            }
        }

        //create method
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened.");

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //return number of affected role 
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);
            connection.Close();
            Console.WriteLine("Connection Closed.");

            //check create data success or not.
            string message = result > 0 ? "Create Successful." : "Create Failed.";
            Console.WriteLine(message);
        }

        //update method 
        public void Update(int id,string title, string author, string content) 
        { 
            SqlConnection connection =new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened.");
            //sql query 
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId",id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //return number of affected rows
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);
            connection.Close();
            Console.WriteLine("Connection Closed.");

            //check update success or not.
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);
        }

        //edit method 
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened.");

            string query = @"select BlogId, BlogTitle, BlogAuthor, BlogContent from tbl_blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddWithValue("@BlogId" , id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //return number of affected rows
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);

            connection.Close();
           
            Console.WriteLine("Connection Closed.");
            //check data empty or not 
            if (dt.Rows.Count == 0 )
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Blog Id =>" + dr["BlogId"]);
            Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
            Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
            Console.WriteLine("------------------------------------");

        }

        //delete method 
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection (_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened.");
            //sql query 
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);

            connection.Close();
            Console.WriteLine("Connection Closed.");
            //check delete success or fail.
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message); 
        }


    }
}
 