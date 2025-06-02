namespace Sfär.Core.Components.CelestialBodies;

public struct MoonData
{
    int Mass { get; set; }
    int Size { get; set; }
    int ParentId { get; set; } // this creates local orbit?
}