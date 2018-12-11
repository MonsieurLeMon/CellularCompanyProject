using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetLogger
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger(string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
