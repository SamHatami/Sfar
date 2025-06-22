using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct PowerGeneration:IDataComponent
{ 
    public int Value { get; init; }
}