namespace Common.Models
{
    public class MinutesBankPackageModel : PackageModel
    {
        public double MinutesBankPrice { get; set; }
        public int AmountOfMinutesInPackage { get; set; }
        public int AmountOfSmsInPackage { get; set; }
    }
}
