using Sfär.Core.Interfaces;

namespace Sfär.Core.Components;

public struct Name : IDataComponent
{
    public Name(string value)
    {
        Value = value;
    }

    private string Value { get; set; }
}