using Sfär.Core.Interfaces;
using Sfär.Core.Utility;

namespace Sfär.Core.Components;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; }
}