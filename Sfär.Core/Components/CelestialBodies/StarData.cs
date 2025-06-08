namespace Sfär.Core.Components.CelestialBodies;

public struct StarData 
{
    public int Mass { get; set; } //1 equals Sol
    public int Size { get; set; } //1 equals Sol
    public float Age { get; set; } //1 = billion
    public string SpectralClass { get; set; }
    public float Luminosity { get; set; } //1 is Sol strength
}