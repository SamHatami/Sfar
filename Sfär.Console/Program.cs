// See https://aka.ms/new-console-template for more information

using System.Timers;
using Sfär.Core;
using Sfär.Core.Managers;
using Sfär.Core.Orbits;

bool isUpdating = false;

SystemManager systemManager = new SystemManager();
Universe universe = new Universe();

universe.Start();

Time time = new Time(0,0,0,0);
time.Start();
time.timer.Elapsed += TimerOnElapsed;
Console.ReadKey();

void TimerOnElapsed(object? sender, ElapsedEventArgs e)
{
    if(isUpdating) return;
    
    isUpdating = true;
    systemManager.Update(Time.TimeStep);
    isUpdating = false;
    
    Console.WriteLine($"Cycle: {time.Cycle} {time.Month} {time.Day} {time.Hour}");

}

