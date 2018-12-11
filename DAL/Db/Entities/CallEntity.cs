using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Db.Entities
{
    public class CallEntity
    {
        [Key]
        public int CallId { get; set; }
        public int LineId { get; set; }
        public DateTime DateCreated { get; set; }
        public double Duration { get; set; }
        public string DestinationNumber { get; set; }
    }
}
