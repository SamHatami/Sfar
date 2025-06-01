using Sfär.Core.Components.Enums;

namespace Sfär.Core.Components;

public struct CelestialBodyData : IComponent
{
    CelestialObjectType Type { get; set; }
    int Mass { get; set; }
    int Size { get; set; }
}