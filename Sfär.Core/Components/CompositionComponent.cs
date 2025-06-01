using Sfär.Core.Components.DataBases;

namespace Sfär.Core.Components;

public struct CompositionComponent
{
    public Dictionary<MaterialType, int> Materials { get; set; }
    
}

//Imaterial => density, value, tier