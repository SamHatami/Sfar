namespace Sfär.Core.Components.CelestialBodies;

public class PlanetData: IComponent
{
    public int Mass { get; set; } //integer multiples of earth mass
    public int Size { get; set; } //integer multiples of earth sizes, float in the future?
    public int Moons { get; set; } //requires moon id linkage?
    
}