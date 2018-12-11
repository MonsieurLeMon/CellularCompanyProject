namespace DAL.Db
{
    using DAL.Db.Entities;
    using System.Data.Entity;

    public class CellularDbContext : DbContext
    {
        public CellularDbContext()
            : base("name=CellularDbContext")
        {
            Database.SetInitializer(new DbInit());
        }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<LineEntity> Lines { get; set; }
        public virtual DbSet<PackageEntity> Packages { get; set; }
        public virtual DbSet<MinutesBankPackageEntity> MinutesPackages { get; set; }
        public virtual DbSet<SpecialPricePackageEntity> SpecialPricePackages { get; set; }
        public virtual DbSet<CallEntity> Calls { get; set; }
        public virtual DbSet<SMSEntity> SMSMessages { get; set; }
        public virtual DbSet<BillEntity> Bills { get; set; }
        public virtual DbSet<ServiceCenterCallEntity> ServiceCalls { get; set; }
    }
}