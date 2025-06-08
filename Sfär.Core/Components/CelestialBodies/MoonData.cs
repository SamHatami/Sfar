namespace Sfär.Core.Components.CelestialBodies;

public struct MoonData
{
    private int Mass { get; set; }
    private int Size { get; set; }
    private int ParentId { get; set; } // this creates local orbit?
}