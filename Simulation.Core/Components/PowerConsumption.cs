using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct PowerConsumption : IDataComponent
{
    public int Value { get; set; }
}