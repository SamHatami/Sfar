using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Celestial;

//This is calculated once when the astronomical object is created.
public struct Period : IDataComponent
{
    public Period(float totalDays)
    {
        TotalDays = totalDays / 24;
        TotalMonths = TotalDays / 30;
        TotalCycles = TotalMonths / 12;
        IngameTime = (int)(totalDays*(Time.tick / 1000)); //Seconds
    }

    public int IngameTime { get; set; }
    public float TotalHours { get; set; }
    public float TotalDays { get; set; } 
    public float TotalMonths { get; set; }
    public float TotalCycles { get; set; }
}