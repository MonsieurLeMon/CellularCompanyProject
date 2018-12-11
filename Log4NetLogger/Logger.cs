using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetLogger
{
    public static class Logger
    {
        public static readonly log4net.ILog log = LogHelper.GetLogger();

        static void Main(string[] args)
        {

        }
    }
}
