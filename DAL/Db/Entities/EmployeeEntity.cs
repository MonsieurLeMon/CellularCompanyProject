using Common.Enums;

namespace DAL.Db.Entities
{
    public class EmployeeEntity : UserEntity
    {
        public string Username { get; set; }
        public EmployeeRole Role { get; set; }
    }
}
