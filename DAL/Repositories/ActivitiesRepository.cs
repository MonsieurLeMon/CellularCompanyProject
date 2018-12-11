using DAL.Db;
using DAL.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ActivitiesRepository
    {
        #region Add
        public bool AddActivity(CallEntity call)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    context.Calls.Add(call);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {/**/ return false; }
        }

        public bool AddActivity(SMSEntity sms)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    context.SMSMessages.Add(sms);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {/**/ return false; }
        }

        public bool AddActivity(IEnumerable<CallEntity> calls)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    context.Calls.AddRange(calls);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {/**/return false; }
        }

        public bool AddActivity(IEnumerable<SMSEntity> smss)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    context.SMSMessages.AddRange(smss);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {/**/return false; }
        }
        #endregion

        #region Get
        public IEnumerable<CallEntity> GetAllCalls()
        {
            var calls = new List<CallEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    calls = (from c in context.Calls
                             select c).ToList();
                }
                return calls;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<CallEntity> GetCallsForLine(int lineId)
        {
            var calls = new List<CallEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    calls = (from c in context.Calls
                             where c.LineId == lineId
                             select c).ToList();
                }
                return calls;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<CallEntity> GetCallsForLineForMonth(int lineId, int month, int year)
        {
            var calls = new List<CallEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    calls = (from c in context.Calls
                             where c.LineId == lineId && c.DateCreated.Month == month && c.DateCreated.Year == year
                             select c).ToList();
                }
                return calls;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<SMSEntity> GetAllSMSs()
        {
            var smss = new List<SMSEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    smss = (from s in context.SMSMessages
                            select s).ToList();
                }
                return smss;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<SMSEntity> GetSMSsForLine(int lineId)
        {
            var smss = new List<SMSEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    smss = (from c in context.SMSMessages
                            where c.LineId == lineId
                            select c).ToList();
                }
                return smss;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<SMSEntity> GetSMSsForLineForMonth(int lineId, int month, int year)
        {
            var smss = new List<SMSEntity>();
            try
            {
                using (var context = new CellularDbContext())
                {
                    smss = (from c in context.SMSMessages
                            where c.LineId == lineId && c.DateCreated.Month == month && c.DateCreated.Year == year
                            select c).ToList();
                }
                return smss;
            }
            catch (Exception)
            { throw; }
        }
        #endregion
    }
}
