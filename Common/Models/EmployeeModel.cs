using Common.Enums;

namespace Common.Models
{
    public class EmployeeModel : UserModel
    {
        public string Username { get; set; }
        public EmployeeRole Role { get; set; }
    }
}
