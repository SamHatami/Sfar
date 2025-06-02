namespace Sfär.Core.Components.CelestialBodies;

public class PlanetData: IComponent
{
    public int Mass { get; set; } //integer multiples of earth mass
    public int Size { get; set; } //integer multiples of earth radius, float in the future?
    public int Density { get; set; }
    public float SurfaceGravity { get; set; }
    public int Moons { get; set; } //requires moon id linkage?
    
}