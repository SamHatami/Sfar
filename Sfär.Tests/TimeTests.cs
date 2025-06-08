using System.Timers;
using Sfär.Core;

namespace Sfär.Tests;

public class TimeTests
{
    public Time time { get; set; }

    [Fact]
    public void TimeStep()
    {
        time = new Time(0, 0, 0, 0);
        time.Start();
        time.timer.Elapsed += TimerOnElapsed;
        Console.ReadKey();
    }
    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        Console.WriteLine(time.tick);
        Console.WriteLine(time.TimeMultiplier);
        Console.WriteLine($"Cycle: {time.Cycle} {time.Month} {time.Day} {time.Hour}");
        
    }
}

