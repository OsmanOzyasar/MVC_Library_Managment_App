using System.ComponentModel.DataAnnotations;

namespace MVC_Library_Management_App.Models
{
    public class CreateBookViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookGenre { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookPublishDate { get; set; }
        public string BookISBN { get; set; }
        public int AvailableBookCopies { get; set; }
        public int AuthorIdV { get; set; }
    }
}
