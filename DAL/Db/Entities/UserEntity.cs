using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
