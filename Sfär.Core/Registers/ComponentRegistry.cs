using Sfär.Core.Components;

namespace Sfär.Core.Registers;

public static class ComponentRegistry
{
    private static Dictionary<int,List<int>> ComponentMap = new(); 
    
    //alternativt en Dictionary<int,ulong> där uLong får bit-operation. Men för att få ut index för varje entitet så behövs en loop genom ulong oavsett?
    
    //go through assembly and namespace and add to this dictionary instead.....
    private static Dictionary<Type, int> ComponentIds = new()
    {
        { typeof(Age), 0 },
        { typeof(Gravity), 1 },
        { typeof(Luminosity), 2 },
        { typeof(Mass), 3 },
        { typeof(MaterialComposition), 4 },
        { typeof(Name), 5 },
        { typeof(Parent), 6 },
        { typeof(Position), 7 },
        { typeof(Size), 8 },
        { typeof(SpectralClass), 9 },
        { typeof(OrbitalVelocity), 10 },
        { typeof(OrbitalPath), 11},
        { typeof(Period), 12}
    };
    
    

    public static int GetId<T>()
    {
        return ComponentIds[typeof(T)];
    }

    public static void AddToComponentMap<T>(int entityId)
    {
        var componentId = GetId<T>();
        
        if (!ComponentMap.ContainsKey(componentId))
            ComponentMap.Add(componentId, new List<int>());
        
        var componentMask = ComponentMap[componentId];
        componentMask.Add(entityId);
    }

    public static int[] GetEntityIdsFor<T>()
    {
        var componentId = GetId<T>();
        var componentMask = ComponentMap[componentId];
        
        //nä....det här är inte mycket bättre?

        return componentMask.ToArray();
    }

    //which entities have specific components?
}