namespace DAL.Db.Entities
{
    public class SpecialPricePackageEntity : PackageEntity
    {
        public double PackagePricePerMinute { get; set; }
        public double PackagePricePerSMS { get; set; }
    }
}
