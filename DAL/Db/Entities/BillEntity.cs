using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class BillEntity
    {
        [Key]
        public int BillId { get; set; }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double TotalPrice { get; set; }

        public List<string> Lines { get; set; }

        public List<int> PackagesIds { get; set; }
    }
}
