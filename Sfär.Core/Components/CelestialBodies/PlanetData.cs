using Sfär.Core.Components.DataBases;

namespace Sfär.Core.Components.CelestialBodies;

public struct PlanetData: IComponent
{
    public int Mass { get; set; } //integer multiples of earth mass
    public float Size { get; set; } //integer multiples of earth radius, float in the future?
    public int Density { get; set; }
    public float SurfaceGravity { get; set; }
    public int Moons { get; set; } //requires moon id linkage?
    public Dictionary<MaterialType, int> Compostion { get; set; }
    
    public Dictionary<MaterialType, int> Compostion { get; set; }
    
}