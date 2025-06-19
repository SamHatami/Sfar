using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Station;

public struct FusionCore:IDataComponent
{
    public int CurrentLoad { get; set; }
}