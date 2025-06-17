using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Station;

public struct FusionCore:IDataComponent
{
    public int TechTier { get; set; } 
    public int Capacity { get; set; }
    public int CurrentLoad { get; set; }
}