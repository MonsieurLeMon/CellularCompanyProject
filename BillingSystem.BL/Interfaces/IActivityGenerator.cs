using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BL.Interfaces
{
    interface IActivityGenerator
    {
        IEnumerable<LineModel> GetAllLines();
        bool SaveAllNewCallsToDb(List<IActivity> activities);
        IActivity GenerateCall(LineModel line);
    }
}
