using System.Collections.Generic;
using Common.Enums;

namespace DAL.Db.Entities
{
    public class CustomerEntity : UserEntity
    {
        public virtual List<LineEntity> Lines { get; set; }
        public CustomerType Customer_Type { get; set; }
    }
}
