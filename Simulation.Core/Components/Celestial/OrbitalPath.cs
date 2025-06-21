using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Celestial;

public struct OrbitalPath : IDataComponent
{
    public OrbitalPath(int majorAxis, int minorAxis, int tiltX, int tiltY, int tiltZ, float inPlanarRotation, float currentAngle)
    {
        MajorAxis = majorAxis;
        MinorAxis = minorAxis;
        MeanDistance = (MajorAxis +  MinorAxis)/2;
        TiltX = tiltX;
        TiltY = tiltY;
        TiltZ = tiltZ;
        InPlanarRotation = inPlanarRotation;
        CurrentAngle = currentAngle;
    }

    public int MeanDistance { get; set; }
    public required int MajorAxis { get; init; }
    public required int MinorAxis { get; init; }
    public int TiltX { get; init; }
    public int TiltY { get; init; }
    public int TiltZ { get; init; }
    public float InPlanarRotation { get; init; } 
    public required float CurrentAngle { get; set; }
}