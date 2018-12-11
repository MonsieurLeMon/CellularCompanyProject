using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class LineEntity
    {
        [Key]
        public int LineId { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        [Required]
        public string LineNumber { get; set; }
        public virtual List<PackageEntity> Packages { get; set; }
        //public virtual List<CallEntity> Calls { get; set; }
        //public virtual List<SMSEntity> SMSMessages { get; set; }
    }
}
