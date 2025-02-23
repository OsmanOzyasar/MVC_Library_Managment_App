using System.ComponentModel.DataAnnotations;

namespace MVC_Library_Management_App.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
