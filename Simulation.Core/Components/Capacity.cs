using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Capacity: IDataComponent
{
    public int Max { get; init; }
    public int Current { get; init; }
}