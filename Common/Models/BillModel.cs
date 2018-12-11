using System.Collections.Generic;

namespace Common.Models
{
    public class BillModel
    {
        public int BillId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public double TotalPrice { get; set; }

        public ICollection<LineModel> Lines { get; set; }

        public List<PackageModel> Packages { get; set; }
    }
}