using Common.Models;
using Converters;
using DAL.Repositories;
using Generators;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BillingSystem.BL.ActivityGenerators
{
    public class CallsGenerator
    {
        public CallsGenerator()
        {
            FromProgramToDb = new ConvertFromProgramToDb();
            FromDbToProgram = new ConvertFromDbToProgramModel();
            LRepo = new LineRepository();
            ARepo = new ActivitiesRepository();
        }

        #region Properties and Instances
        private int maxValue = 200;
        private ConvertFromProgramToDb FromProgramToDb { get; set; }
        private ConvertFromDbToProgramModel FromDbToProgram { get; set; }
        private LineRepository LRepo { get; set; }
        private ActivitiesRepository ARepo { get; set; }
        #endregion

        public bool GenerateCalls()
        {
            var allLines = GetAllLines();
            var calls = new List<CallModel>();

            foreach (var line in allLines)
            {
                calls.AddRange(GenerateCallsForLine(line));
            }

            if (SaveAllNewCallsToDb(calls))
                return true;
            else return false;
        }

        private IEnumerable<CallModel> GenerateCallsForLine(LineModel line)
        {
            Random rnd = new Random();
            int amountOfCalls = rnd.Next(maxValue); // randomise number of calls to generate
            List<CallModel> calls = new List<CallModel>();

            for (int i = 0; i < amountOfCalls; i++)
            {
                CallModel newCall = GenerateCall(line);
                if (newCall != null)
                    calls.Add(newCall);
            }

            return calls;
        }

        private CallModel GenerateCall(LineModel line)
        {
            Thread.Sleep(5);
            var gen = new Generator();

            var newCall = new CallModel
            {
                LineId = line.LineId,
                DestinationNumber = gen.GeneratePhoneNumber(),
                Duration = gen.GenerateCallDuration(),
                DateActivityMade = gen.GenerateDate()
            };

            return newCall;
        }

        #region Data Access Methods
        private IEnumerable<LineModel> GetAllLines()
        {
            var dbLines = LRepo.GetAllLines();
            IEnumerable<LineModel> lines = FromDbToProgram.ConvertLine(dbLines);
            return lines;
        }

        private bool SaveAllNewCallsToDb(IEnumerable<CallModel> calls)
        {
            var convertedCalls = FromProgramToDb.ConvertCall(calls);

            if (ARepo.AddActivity(convertedCalls))
                return true;
            return false;
        }
        #endregion
    }
}