using Sfär.Core.Interfaces;
using Sfär.Core.Utility;

namespace Sfär.Core.Components;

public struct OrbitalPath : IDataComponent
{
    public OrbitalPath(int majorAxis, int minorAxis, int tiltX, int tiltY, int tiltZ, float inPlanarRotation, float currentAngle)
    {
        MajorAxis = majorAxis;
        MinorAxis = minorAxis;
        TiltX = tiltX;
        TiltY = tiltY;
        TiltZ = tiltZ;
        InPlanarRotation = inPlanarRotation;
        CurrentAngle = currentAngle;
    }

    public required int MajorAxis { get; set; }
    public required int MinorAxis { get; set; }
    public int TiltX { get; set; }
    public int TiltY { get; set; }
    public int TiltZ { get; set; }
    public float InPlanarRotation { get; set; } 
    public int Perimeter { get; set; }
    
    public required float CurrentAngle { get; set; }
}