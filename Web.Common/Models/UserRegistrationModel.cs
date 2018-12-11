using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Common.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Add First Name"), DisplayName("First Name"), MinLength(2, ErrorMessage = "First Name Must Contain At Least 2 Characters"), MaxLength(50, ErrorMessage = "First Name Must Contain At Most 50 Characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Must Add Last Name"), DisplayName("Last Name"), MinLength(2, ErrorMessage = "Last Name Must Contain At Least 2 Characters"), MaxLength(50, ErrorMessage = "Last Name Must Contain At Most 50 Characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Must Add Password"), MinLength(5, ErrorMessage = "Password Must Contain At Least 5 Characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Must Add Email Address"), DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }
}
