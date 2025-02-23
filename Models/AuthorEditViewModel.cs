using System.ComponentModel.DataAnnotations;

namespace MVC_Library_Management_App.Models
{
    public class AuthorEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
