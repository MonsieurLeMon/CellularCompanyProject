using Common.Interfaces;
using System;

namespace Common.Models
{
    public class SMSModel : IActivity
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public DateTime DateActivityMade { get; set; }
        public string DestinationNumber { get; set; }
    }
}
