namespace Common.Models
{
    public abstract class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}