using Sfär.Core.Interfaces;
using Sfär.Core.Utility.MathExtension;

namespace Sfär.Core.Components.Generic;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; }
}