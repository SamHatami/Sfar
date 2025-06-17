using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Celestial;

public struct OrbitalVelocity : IDataComponent
{
    public bool IsClockWise { get; set; } 
    public required float Value { get; set; } // rad/singleTimsptep 
}