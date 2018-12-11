using Converters;
using DAL.Repositories;
using Common.Models;

namespace CRM.BL.CrmServices
{
    public class PackageServices
    {
        public PackageServices()
        {
            Repo = new PackageRepository();
            FromProgramToDb = new ConvertFromProgramToDb();
            FromDbToProgram = new ConvertFromDbToProgramModel();
        }

        public PackageRepository Repo { get; set; }
        public ConvertFromProgramToDb FromProgramToDb { get; set; }
        public ConvertFromDbToProgramModel FromDbToProgram { get; set; }

        public bool AddPackageToLine(MinutesBankPackageModel package, int lineId)
        {
            var convertedPackage = FromProgramToDb.ConvertMinutesPackage(package);
            if (Repo.AddPackage(convertedPackage, lineId))
                return true;
            return false;
        }
        public bool AddPackageToLine(SpecialPricePackageModel package, int lineId)
        {
            var convertedPackage = FromProgramToDb.ConvertSpecialPackage(package);
            if (Repo.AddPackage(convertedPackage, lineId))
                return true;
            return false;
        }
    }
}
