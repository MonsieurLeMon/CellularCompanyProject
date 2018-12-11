namespace DAL.Db.Entities
{
    public class MinutesBankPackageEntity : PackageEntity
    {
        public double MinutesBankPrice { get; set; }
        public int AmountOfMinutesInPackage { get; set; }
        public int AmountOfSmsInPackage { get; set; }
    }
}
