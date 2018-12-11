using Common.Enums;

namespace Common.Models
{
    public class LoginResult
    {
        public bool Result { get; set; }
        public int Id { get; set; }
        public EmployeeRole Emp_Role { get; set; }
    }
}
