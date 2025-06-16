using Sfär.Core;
using Sfär.Core.Enums;

public struct ComponentMap
{
    public Type ComponentType { get;}
    private int[] EntitysId = new int[GlobalSettings.MaxEntities];

    public ComponentMap(Type componentType)
    {
        ComponentType = componentType;
    }

    public void AddUsage(int entityId)
    {
        EntitysId.Append(entityId);
    }

    public ReadOnlySpan<int> GetUsageIds()
    {
        return EntitysId.AsSpan();
    }
}