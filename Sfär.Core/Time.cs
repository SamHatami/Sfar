using System.Timers;
using Timer = System.Timers.Timer;

namespace Sfär.Core;

public class Time
{
    public Timer tick { get; private set; }
    private int _timeStep => 6000/TimeMultiplier; // 6 real time seconds corresponds to one hour
    public int TimeMultiplier { get; set; } = 10; // 2 / 4 / 6 
    public int Cycle { get; set; } // Corresponds to year
    public int Month { get; set; } 
    public int Day { get; set; } 
    public int Hour { get; set; }
    
    public Time(int cycle, int month, int day, int currentHour = 0)
    {
        Cycle = cycle;
        Month = month;
        Day = day;
    }

    public void Start()
    {
        tick = new Timer();
        tick.Interval = _timeStep;
        tick.Start();
        tick.Elapsed += TimerOnElapsed;
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        Hour = (Hour +1) % 24 ;
        
        Day = (Day + (Hour % 24 == 0 ? 1 : 0) % 30);
        
        Month = (Month + (Day % 30 == 0 ? 1 : 0) % 12);
        
        Cycle = (Cycle + (Month % 12 == 0 ? 1 : 0));
    }

}