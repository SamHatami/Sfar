using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Celestial;

public struct Gravity : IDataComponent
{
    public float Value { get; set; }
}