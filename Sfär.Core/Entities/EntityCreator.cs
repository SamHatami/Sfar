using static Sfär.Core.GlobalSettings;

namespace Sfär.Core.Entities;

public static class EntityCreator
{
    private static int[] _usedIds = new int[MaxEntities]; //on loading this should have been saved
    private static int currentId;
    
    public static IEntity Create()
    {
        var entity = new Entity(currentId);
        currentId++;
        return entity;
    }

    public static void Remove(int id)
    {
        
    }


    private struct Entity : IEntity
    {
        public int Id { get; }
        public string Label { get; set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}