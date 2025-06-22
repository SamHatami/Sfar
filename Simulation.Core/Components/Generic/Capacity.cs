using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Generic;

public struct Capacity: IDataComponent
{
    public int Max { get; init; }
    public int Current { get; init; }
}