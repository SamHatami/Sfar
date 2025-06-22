using System.Timers;
using Simulation.Core;

namespace Simulation.Tests;

public class TimeTests
{
    public Time time { get; set; }

    [Fact]
    public void TimeStep()
    {
        time = new Time(0, 0, 0);
        time.Start();
        time.timer.Elapsed += TimerOnElapsed;
        Console.ReadKey();
    }
    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        Console.WriteLine($"Cycle: {time.Cycle} {time.Month} {time.Day} {time.Hour}");
    }
}

