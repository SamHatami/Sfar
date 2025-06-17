using Sfär.Core.DataBases;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Celestial;

public struct MaterialComposition : IDataComponent
{
    public Dictionary<MaterialType, int> Materials { get; set; }
}