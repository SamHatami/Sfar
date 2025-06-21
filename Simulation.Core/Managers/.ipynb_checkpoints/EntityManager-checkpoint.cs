using Sfär.Core.Entities;
using static Sfär.Core.GlobalSettings;

namespace Sfär.Core.Managers;

public static class EntityManager
{
    private static int[] _usedIds = new int[MaxEntities]; //on loading this should have been saved
    private static int currentId;
    
    public static Entity[] Entities { get; } = new Entity[MaxEntities]();

    public static Entity CreateEntity()
    {
        var entity = new Entity(currentId);
        currentId++;
        Entities.Add(entity);
        return entity;
    }
    
    public static void Remove(int id)
    {
    }
}