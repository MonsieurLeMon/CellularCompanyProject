using System;

namespace Common.Interfaces
{
    public interface IActivity
    {
        int Id { get; set; }
        int LineId { get; set; }
        DateTime DateActivityMade { get; set; }
        string DestinationNumber { get; set; }
    }
}
