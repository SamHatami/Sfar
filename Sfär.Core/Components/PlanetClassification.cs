using Sfär.Core.Components.Enums;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Components;

public struct PlanetClassification : IDataComponent
{
    public PlanetType PlanetType { get; set; }
    public PlanetSizeClass SizeClass { get; set; }
    
}