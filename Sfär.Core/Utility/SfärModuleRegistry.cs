using System.Numerics;

namespace Sfär.Core.Utility;

public class SfärModuleRegistry
{

    public Vector3[] OccupiedPositions { get; private set; }

    public SfärModuleRegistry()
    {
        
    }
    
    public static bool IsWithinBounds(int innerRadialBound, int externalRadialBound, Vector3 p)
    {
        //Thick "Shell"
        // iSr = innerboundary of the Sphere Radius
        // oSr = outer boundary of the sphere radius
        
        var iSr = innerRadialBound*innerRadialBound;
        var oSr = externalRadialBound*externalRadialBound;
        var slotCenter = p.X *  p.X + p.Y * p.Y + p.Z * p.Z;
        return slotCenter >iSr && slotCenter <oSr;
    }
    
}