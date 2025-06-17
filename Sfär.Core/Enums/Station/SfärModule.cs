using Sfär.Core.Interfaces;

namespace Sfär.Core.Enums.Station;

public struct SfärModule:IDataComponent
{
    public ModuleType ModuleType { get; } //used for power consumption
    public int Size { get; } //used for power consumption
}