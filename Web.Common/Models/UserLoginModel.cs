using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Models
{
    public class UserLoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone Number Not Entered"), DisplayName("Phone Number"), MinLength(10, ErrorMessage = "Phone Number Must Have 10 Numbers"), MaxLength(10, ErrorMessage = "Phone Number Must Have 10 Numbers")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password Not Entered"), MinLength(4, ErrorMessage = "Must Contain at least 4 characters")]
        public string Password { get; set; }
    }
}
