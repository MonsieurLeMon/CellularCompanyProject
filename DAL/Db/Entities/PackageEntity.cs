using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class PackageEntity
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public string PackageName { get; set; }
        [Required]
        public double BasePricePerMinute { get; set; }
        [Required]
        public double BasePricePerSMS { get; set; }

        public DateTime DateActivated { get; set; }

        public DateTime? DateCancled { get; set; }
    }
}
