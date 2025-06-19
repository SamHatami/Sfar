using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Station;

public struct PowerConsumption : IDataComponent
{
    public int Value { get; set; }
}