using BookShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using BookShop.SqlServar;
using System.Data.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace BookShop.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {


        SqlServerConnection ssConnection = new SqlServerConnection();

        // GET: BookController

        

        [HttpGet]
        public APIResponse GetAllBooks()
        {
            List<Book> bookList = new List<Book>();
            using (SqlConnection conn = ssConnection.OpenConnection())
            {
                string query = "SELECT * from books";
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                // get results into first list from first select
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Book book = new Book();

                        book.Id = (int)reader["Id"];
                        book.BookTitle = (string)reader["BookTitle"];
                        book.BookAuthor = (string)reader["BookAuthor"];
                        book.BookPrice = (int)reader["Bookprice"];
                        book.BookSize = (int)reader["BookSize"];
                        book.PageCount = (int)reader["PageCount"];
                        book.Publisher = (String)reader["Publisher"];

                        bookList.Add(book);
                    }
                    reader.NextResult();
                }
                conn.Close();
            }

            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.data = bookList;
            response1.message = "Books fatched Successfully.";
            return response1;
        }




        // POST api/<BookController>
        [HttpPost]
        public APIResponse CreateBook([FromBody] Book value)
        {


            SqlConnection conn = ssConnection.OpenConnection();

            Debug.WriteLine(value.BookTitle);

            String query = "INSERT INTO books (BookTitle, BookAuthor, BookPrice, BookSize, PageCount, Publisher) VALUES (@BookTitle, @BookAuthor, @BookPrice, @BookSize, @PageCount, @Publisher)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@BookTitle", SqlDbType.VarChar).Value = value.BookTitle;
            command.Parameters.Add("@BookAuthor", SqlDbType.VarChar).Value = value.BookAuthor;
            command.Parameters.Add("@BookPrice", SqlDbType.Int).Value = value.BookPrice;
            command.Parameters.Add("@BookSize", SqlDbType.Int).Value = value.BookSize;
            command.Parameters.Add("@PageCount", SqlDbType.Int).Value = value.PageCount;
            command.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = value.Publisher;

            int response = command.ExecuteNonQuery();
            conn.Close();

            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.data = value;
            response1.message = "book Created Successfully.";
            return response1;
        }




        // POST api/<BookController>
        [Route("author")]
        [HttpPost]

        public APIResponse CreateAuthor([FromBody] Book value)
        {


            SqlConnection conn = ssConnection.OpenConnection();

            Debug.WriteLine(value.BookTitle);

            String query = "INSERT INTO books (BookTitle, BookAuthor, BookPrice, BookSize, PageCount, Publisher) VALUES (@BookTitle, @BookAuthor, @BookPrice, @BookSize, @PageCount, @Publisher)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@BookTitle", SqlDbType.VarChar).Value = value.BookTitle;
            command.Parameters.Add("@BookAuthor", SqlDbType.VarChar).Value = value.BookAuthor;
            command.Parameters.Add("@BookPrice", SqlDbType.Int).Value = value.BookPrice;
            command.Parameters.Add("@BookSize", SqlDbType.Int).Value = value.BookSize;
            command.Parameters.Add("@PageCount", SqlDbType.Int).Value = value.PageCount;
            command.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = value.Publisher;

            int response = command.ExecuteNonQuery();
            conn.Close();

            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.data = value;
            response1.message = "book Created Successfully.";
            return response1;
        }


        // GET: BookController
        [HttpGet("{id}")]
        public APIResponse GetBookById(int id)
        {
            Book book = new Book();

            using (SqlConnection conn = ssConnection.OpenConnection())
            {
                string query = "SELECT * from books where Id="+id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                // get results into first list from first select
               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        book.Id = (int)reader["Id"];
                        book.BookTitle = (string)reader["BookTitle"];
                        book.BookAuthor = (string)reader["BookAuthor"];
                        book.BookPrice = (int)reader["Bookprice"];
                        book.BookSize = (int)reader["BookSize"];
                        book.PageCount = (int)reader["PageCount"];
                        book.Publisher = (String)reader["Publisher"];

                       
                    }
                    reader.NextResult();
                }
                conn.Close();
            }
            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.message = "Book fetched successfully";
            response1.data = book;
            return response1;
        }

        // PUT api/<BookController>
        [HttpPut("{id}")]
        public APIResponse UpdateBookById([FromBody] Book value,int id)
        {


            SqlConnection conn = ssConnection.OpenConnection();

            Debug.WriteLine(value.BookTitle);

            String query = "update books set BookTitle=@BookTitle, BookAuthor=@BookAuthor, BookPrice=@BookPrice, BookSize=@BookSize, PageCount=@BookSize, Publisher=@Publisher where Id=@BookId";
          
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@BookTitle", SqlDbType.VarChar).Value = value.BookTitle;
            command.Parameters.Add("@BookAuthor", SqlDbType.VarChar).Value = value.BookAuthor;
            command.Parameters.Add("@BookPrice", SqlDbType.Int).Value = value.BookPrice;
            command.Parameters.Add("@BookSize", SqlDbType.Int).Value = value.BookSize;
            command.Parameters.Add("@PageCount", SqlDbType.Int).Value = value.PageCount;
            command.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = value.Publisher;
            command.Parameters.Add("@BookId", SqlDbType.Int).Value =id;


            int response = command.ExecuteNonQuery();
            conn.Close();

            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.data = value;
            response1.message = "Book Updated Successfully.";
            return response1;
        }

        //Delete api/<BookController>
        [HttpDelete("{id}")]
        public APIResponse DeleteBookById(int id)
        {


            SqlConnection conn = ssConnection.OpenConnection();

           

            String query = "delete  from books where Id=@BookId";

            SqlCommand command = new SqlCommand(query, conn);

            
            command.Parameters.Add("@BookId", SqlDbType.Int).Value = id;


            int response = command.ExecuteNonQuery();
            conn.Close();

            APIResponse response1 = new APIResponse();
            response1.statusCode = 200;
            response1.data = response;
            response1.message = "Book Deleted Successfully.";
            return response1;
        }
    }

}
