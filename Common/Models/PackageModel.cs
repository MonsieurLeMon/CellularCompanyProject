using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class PackageModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public double BasePricePerMinute { get; set; }
        public double BasePricePerSMS { get; set; }

        public DateTime DateActivated { get; set; }
        public DateTime? DateCancled { get; set; }
    }
}
