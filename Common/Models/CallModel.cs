using System;
using Common.Interfaces;

namespace Common.Models
{
    public class CallModel : IActivity
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public DateTime DateActivityMade { get; set; }
        public double Duration { get; set; }
        public string DestinationNumber { get; set; }
    }
}
