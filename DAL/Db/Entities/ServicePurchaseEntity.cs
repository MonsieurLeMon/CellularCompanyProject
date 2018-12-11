namespace DAL.Db.Entities
{
    public class ServicePurchaseEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int PackageId { get; set; }
    }
}
