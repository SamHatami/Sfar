using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Generic;

public struct PowerGeneration:IDataComponent
{ 
    public int Value { get; init; }
}