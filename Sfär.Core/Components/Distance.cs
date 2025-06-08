using Sfär.Core.Components.Enums;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Components;

public struct Distance : IDataComponent
{
    public float Value { get; set; } // some type of atronomical unit
}