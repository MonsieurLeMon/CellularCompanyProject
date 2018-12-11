using Common.Enums;
using System.Collections.Generic;

namespace Common.Models
{
    public class CustomerModel : UserModel
    {
        public CustomerType Customer_Type { get; set; }
        public ICollection<LineModel> Lines { get; set; }
    }
}