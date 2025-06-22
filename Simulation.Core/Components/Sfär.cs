using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Sfär:IDataComponent
{
    public int innerBound { get; init; } //grows during expansion
    public int outerBound { get; init; } //grows during expansion
    

}