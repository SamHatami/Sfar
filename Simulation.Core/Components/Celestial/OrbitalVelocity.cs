using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Celestial;

public struct OrbitalVelocity : IDataComponent
{
    public bool IsClockWise { get; set; } 
    public required float Value { get; set; } // rad/singleTimsptep 
}