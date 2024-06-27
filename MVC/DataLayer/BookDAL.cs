using MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC.DataLayer
{
    public class BookDAL
    {
        string cnn = string.Empty;

        public BookDAL() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            cnn = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                
                SqlCommand command = new SqlCommand("SelectAllBooks", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book( 
                        
                            bookID: int.Parse(reader["BookID"].ToString()),
                            title: reader["Title"].ToString(),
                            author: reader["Author"].ToString(),
                            publicationYear: int.Parse(reader["PublicationYear"].ToString()),
                            publisher: reader["Publisher"].ToString(),
                            genre: reader["Title"].ToString(),
                            tableOfContentsXml: reader["TableOfContents"].ToString()
                        ));
                    }
                }

                connection.Close();
            }
            return books;
        }public Book GetBook(int id)
        {
            Book book = new Book();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                
                SqlCommand command = new SqlCommand("SelectBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new Book( 
                        
                            bookID: int.Parse(reader["BookID"].ToString()),
                            title: reader["Title"].ToString(),
                            author: reader["Author"].ToString(),
                            publicationYear: int.Parse(reader["PublicationYear"].ToString()),
                            publisher: reader["Publisher"].ToString(),
                            genre: reader["Title"].ToString(),
                            tableOfContentsXml: reader["TableOfContents"].ToString()
                        );
                    }
                }

                connection.Close();
            }
            return book;
        }
    }
}
