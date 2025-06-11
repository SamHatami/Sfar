using Sfär.Core.DataBases;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Components;

public struct MaterialComposition : IDataComponent
{
    public Dictionary<MaterialType, int> Materials { get; set; }
}