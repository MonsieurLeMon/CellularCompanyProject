using Common.Models;
using Converters;
using DAL.Repositories;
using Generators;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BillingSystem.BL.ActivityGenerators
{
    public class SMSGenerator
    {
        public SMSGenerator()
        {
            FromProgramToDb = new ConvertFromProgramToDb();
            FromDbToProgram = new ConvertFromDbToProgramModel();
            LRepo = new LineRepository();
            ARepo = new ActivitiesRepository();
        }

        #region Properties and Instances
        int maxValue = 50;
        private ConvertFromProgramToDb FromProgramToDb { get; set; }
        private ConvertFromDbToProgramModel FromDbToProgram { get; set; }
        private LineRepository LRepo { get; set; }
        private ActivitiesRepository ARepo { get; set; }
        #endregion

        public bool GenerateSMSs()
        {
            var allLines = GetAllLines();
            var smss = new List<SMSModel>();

            foreach (var line in allLines)
            {
                smss.AddRange(GenerateSMSsForLine(line));
            }

            if (SaveAllNewSMSsToDb(smss))
                return true;
            else return false;
        }

        private IEnumerable<SMSModel> GenerateSMSsForLine(LineModel line)
        {
            Random rnd = new Random();
            int amountOfSMSs = rnd.Next(maxValue); // randomise number of sms to generate
            List<SMSModel> SMSs = new List<SMSModel>();

            for (int i = 0; i < amountOfSMSs; i++)
            {
                SMSModel newSMS = GenerateSMS(line);
                if (newSMS != null)
                    SMSs.Add(newSMS);
            }

            return SMSs;
        }

        private SMSModel GenerateSMS(LineModel line)
        {
            Thread.Sleep(5);
            SMSModel newSMS = new SMSModel();
            var gen = new Generator();

            newSMS.LineId = line.LineId;
            newSMS.DestinationNumber = gen.GeneratePhoneNumber(); // gets string that starts with "05" + 8 random numbers
            newSMS.DateActivityMade = gen.GenerateDate();

            return newSMS;
        }

        #region Data Access Methods
        private IEnumerable<LineModel> GetAllLines()
        {
            var dbLines = LRepo.GetAllLines();
            IEnumerable<LineModel> lines = FromDbToProgram.ConvertLine(dbLines);
            return lines;
        }

        private bool SaveAllNewSMSsToDb(List<SMSModel> smss)
        {
            var convertedSMSs = FromProgramToDb.ConvertSMS(smss);

            if (ARepo.AddActivity(convertedSMSs))
                return true;
            return false;
        }
        #endregion
    }
}
