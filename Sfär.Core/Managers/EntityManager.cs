using Sfär.Core.Entities;
using static Sfär.Core.GlobalSettings;

namespace Sfär.Core.Managers;

public static class EntityManager
{  
    public static Entity?[] Entities { get; } = new Entity?[MaxEntities];

    public static Entity? CreateEntity()
    {
        var id = GetNextFreeId();
        var entity = new Entity(id);
        Entities[id] = entity;
        return entity;
    }

    public static void Remove(int id)
    {
        Entities[id] = null;
    }

    private static int GetNextFreeId() => Array.FindIndex(Entities, E => E == null);
    
}