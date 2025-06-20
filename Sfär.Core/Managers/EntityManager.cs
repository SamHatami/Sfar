using Sfär.Core.Entities;
using static Sfär.Core.GlobalSettings;

namespace Sfär.Core.Managers;

public static class EntityManager
{  
    private static Entity?[] _entities { get; } = new Entity?[MaxEntities];

    public static Entity? CreateEntity()
    {
        var id = GetNextFreeId();
        var entity = new Entity(id);
        _entities[id] = entity;
        return entity;
    }

    public static void Remove(int id)
    {
        _entities[id] = null;
    }

    public static Entity? GetEntity(int id) => _entities[id];
    
    private static int GetNextFreeId() => Array.FindIndex(_entities, E => E == null);
    
}