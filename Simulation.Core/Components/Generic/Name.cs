using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Generic;

public struct Name : IDataComponent
{
    public string Value { get; set; }
}