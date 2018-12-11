using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Db.Entities
{
    public class SMSEntity
    {
        [Key]
        public int SMSId { get; set; }
        public int LineId { get; set; }
        public DateTime DateCreated { get; set; }
        public string DestinationNumber { get; set; }
    }
}
