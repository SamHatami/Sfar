using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct Name : IDataComponent
{
    public string Value { get; set; }
}