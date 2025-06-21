using System.Numerics;

namespace Simulation.Core.Utility;

public class SfärModuleRegistry
{
    private List<Vector3> OccupiedPositions { get; } = new();

    public SfärModuleRegistry()
    {
        
    }

    public void OccupySlot(Vector3 position)
    {
        if (OccupiedPositions.Contains(position)) return;
        
        OccupiedPositions.Add(position);
    }
    
    public void FreeSlot(Vector3 position)
    {
        if (!OccupiedPositions.Contains(position)) return;
        
        OccupiedPositions.Remove(position);
    }
    
    public static bool IsWithinBounds(int innerBound, int outerBound, Vector3 p)
    {
        //Thick "Shell" where slots can reside
        // iSr = innerboundary of the Sphere Radius
        // oSr = outer boundary of the sphere radius
        
        var iBsqrd = innerBound*innerBound;
        var oBsqrd = outerBound*outerBound;
        var slotCenter = p.X *  p.X + p.Y * p.Y + p.Z * p.Z;
        return slotCenter >iBsqrd && slotCenter <oBsqrd;
    }
    
}