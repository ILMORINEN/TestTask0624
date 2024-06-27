using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public XElement TableOfContents { get; set; }

        public Book() { }

        public Book(int bookID, string title, string author, int publicationYear, string publisher, string genre, string tableOfContentsXml)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Publisher = publisher;
            Genre = genre;
            TableOfContents = XElement.Parse(tableOfContentsXml);
        }

        public string GetTableOfContentsAsString()
        {
            return TableOfContents.ToString();
        }
    }
}
