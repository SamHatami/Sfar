// See https://aka.ms/new-console-template for more information


using System.Timers;
using Sfär.Core;

Time time = new Time(0, 1, 1, 1);

time.Start();
time.tick.Elapsed += TickOnElapsed;
Console.ReadKey();
void TickOnElapsed(object? sender, ElapsedEventArgs e)
{
    Console.WriteLine($"Current hour: {time.Hour}");
    Console.WriteLine($"Current day: {time.Day}");
    Console.WriteLine($"Current month: {time.Month}");
    Console.WriteLine($"Current cycle: {time.Cycle}");
}




