using DAL.Db;
using DAL.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class LineRepository
    {
        public bool AddLine(LineEntity line, int customerId)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    var customer = (from c in context.Customers
                                    where c.UserId == customerId
                                    select c).FirstOrDefault();
                    customer.Lines.Add(line);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // write to log fatal error;
                return false;
            }
        }

        public bool IsLineExist(string phoneNumber)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    bool contains = context.Lines.Any(l => l.LineNumber == phoneNumber);
                    return contains;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public LineEntity GetLine(string phoneNumber)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    var line = (from l in context.Lines
                                where l.LineNumber == phoneNumber
                                select l).FirstOrDefault();
                    return line;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LineEntity> GetAllLines()
        {
            var lines = new List<LineEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    lines = (from l in context.Lines
                             select l).ToList();
                }
                return lines;
            }
            catch (Exception)
            {
                // Write To Log fatal
                throw;
            }
        }
    }
}
