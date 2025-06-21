using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Generic;

public struct Capacity: IDataComponent
{
    public int Max { get; set; }
    public int Current { get; set; }
}