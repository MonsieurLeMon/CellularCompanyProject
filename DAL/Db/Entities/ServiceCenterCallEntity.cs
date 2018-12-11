using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class ServiceCenterCallEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime DateOfCall { get; set; }

        public string Description { get; set; }
    }
}
