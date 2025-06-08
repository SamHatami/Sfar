using System.Timers;
using Timer = System.Timers.Timer;

namespace Sfär.Core;

public class Time
{
    private int _totalHours;

    public Time(int cycle, int month, int day, int currentHour = 0)
    {
        Cycle = cycle;
        Month = month;
        Day = day;
    }

    public Timer timer { get; private set; }
    public static int tick => 100 ; // time that corresponds to ingame hour
    public static int TimeStep { get; set; } = 1; // 2 / 4 / 6 
    public int Cycle { get; set; } // Corresponds to year
    public int Month { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }

    public void Start()
    {
        timer = new Timer();
        timer.Interval = tick;
        timer.Start();
        timer.Elapsed += TimerOnElapsed;
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        Hour += TimeStep;
    
        if (Hour < 24) return;
        Day += Hour / 24;
        Hour %= 24;

        if (Day < 30) return;
        Month += Day / 30;
        Day %= 30;

        if (Month < 12) return;
        Cycle += Month / 12;
        Month %= 12;
    }
}