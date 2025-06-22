using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Gravity : IDataComponent
{
    public float Value { get; set; }
}