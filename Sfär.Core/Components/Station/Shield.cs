using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Station;

public struct Shield : IDataComponent
{
    public int EnergyRequired { get; set; }
    public int Integrity { get; set; }
}