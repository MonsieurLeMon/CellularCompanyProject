using System;
using System.Text;
using Log4NetLogger;

namespace Generators
{
    public class Generator
    {
        public Random Rand { get; set; }

        // return string that starts with "05" + 8 random numbers 
        public string GeneratePhoneNumber()
        {
            StringBuilder sb = new StringBuilder("05");
            Rand = new Random();

            while (sb.Length < 10)
            {
                sb.Append(Rand.Next(0, 10).ToString());
            }

            return sb.ToString();
        }

        // return double from 0 to 60
        public double GenerateCallDuration()
        {
            Rand = new Random();
            double duration = Rand.Next(0, 60);
            return duration;
        }

        // return random date from last month
        public DateTime GenerateDate()
        {

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month - 1;
            int day;
            do
            {
                day = Rand.Next(DateTime.DaysInMonth(year, month) + 1);
            } while (day == 0);

            DateTime date = new DateTime(year, month, day);
            try
            {
                return date;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Logger.log.Error(e.Message, e);
                return GenerateDate();
            }
        }
    }
}