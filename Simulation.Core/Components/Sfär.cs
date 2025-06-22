using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Sfär:IDataComponent
{
    public int innerBound { get; set; } //grows during expansion
    public int outerBound { get; set; } //grows during expansion
    

}