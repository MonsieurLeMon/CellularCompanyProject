using DAL.Db;
using DAL.Db.Entities;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class PackageRepository
    {
        public bool AddPackage(PackageEntity package, int lineId)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    var line = (from l in context.Lines
                                where l.LineId == lineId
                                select l).FirstOrDefault();
                    line.Packages.Add(package);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
