using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Age : IDataComponent
{
    public float Value { get; set; } // 1 = billion years   
}