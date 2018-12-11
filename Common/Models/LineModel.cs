using System.Collections.Generic;

namespace Common.Models
{
    public class LineModel
    {
        public int LineId { get; set; }
        public int CustomerId { get; set; }
        public string LineNumber { get; set; }
        public List<PackageModel> Packages { get; set; }
    }
}
