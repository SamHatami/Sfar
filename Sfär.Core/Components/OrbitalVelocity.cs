using Sfär.Core.Interfaces;

namespace Sfär.Core.Components;

public struct OrbitalVelocity : IDataComponent
{
    public bool IsClockWise { get; set; } 
    public required float Value { get; set; } // rad/singleTimsptep 
}