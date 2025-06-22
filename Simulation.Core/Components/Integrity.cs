using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Integrity:IDataComponent
{
    public int Value { get; set; } //0-100
}