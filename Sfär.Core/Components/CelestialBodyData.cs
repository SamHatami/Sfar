using Sfär.Core.Components.Enums;

namespace Sfär.Core.Components;

public struct CelestialBodyData : IComponent
{
    CelestialBodyType Type { get; set; }
    int Mass { get; set; }
    int Size { get; set; }
    int Density { get; set; }
}