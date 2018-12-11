using DAL.Db;
using DAL.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BillRepository
    {
        public bool AddBill(BillEntity bill)
        {
            try
            {
                using (var db = new CellularDbContext())
                {
                    db.Bills.Add(bill);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { /* write to log */ return false; }
        }

        public bool AddBill(IEnumerable<BillEntity> bills)
        {
            try
            {
                using (var db = new CellularDbContext())
                {
                    db.Bills.AddRange(bills);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { /* write to log */ return false; }
        }

        public BillEntity GetBill(int id, int month, int year)
        {
            var bill = new BillEntity();
            using (var db = new CellularDbContext())
            {
                bill = (from b in db.Bills
                        where b.CustomerId == id && b.Month == month && b.Year == year
                        select b).FirstOrDefault();
            }
            return bill;
        }
    }
}
