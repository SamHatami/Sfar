using System.ComponentModel;
using Sfär.Core.Entities;

namespace Sfär.Core.Components;

public static class ComponentManager
{
    static SpatialComponent[] SpatialComponents = new SpatialComponent[GlobalSettings.MaxEntities];
    static PhysicalComponent[] PhysicalComponents = new PhysicalComponent[GlobalSettings.MaxEntities];
    static CompositionComponent[]  CompositionComponents = new CompositionComponent[GlobalSettings.MaxEntities];


    //Extension to Ientities
    public static void AddComponent<T>(this IEntity entity, T component) where T : IComponent
    {
        switch (component)
        {
            case SpatialComponent spatialComponent:
                SpatialComponents[entity.Id] = spatialComponent;
                break;
            case PhysicalComponent physicalProperty:
                PhysicalComponents[entity.Id] = physicalProperty;
                break;
            case CompositionComponent compositionComponent:
                CompositionComponents[entity.Id] = compositionComponent;
                break;
        }
    }

    public static void RemoveComponent<T>(this IEntity entity) where T : struct, IComponent
    {
        
        if(!TryGetComponent<T>(entity.Id, out var component)) return;

        switch (typeof(T))
        {
            case Type t when t == typeof(SpatialComponent):
                SpatialComponents[entity.Id] = default;
                break;
            case Type t when t == typeof(PhysicalComponent):
                PhysicalComponents[entity.Id] = default;
                break;
            case Type t when t == typeof(CompositionComponent):
                CompositionComponents[entity.Id] = default;
                break;
        }
    }

    public static bool TryGetComponent<T>(int id, out T? component) where T : struct, IComponent
    {
        component = GetComponent<T>(id);
        return component != null;
    }

    private static T? GetComponent<T>(int id) where T: struct, IComponent
    {
        if (id < 0 || id >= GlobalSettings.MaxEntities) return default;

        switch (typeof(T))
        {
            case Type t when t == typeof(SpatialComponent):
                return SpatialComponents[id] as T?;
            case Type t when t == typeof(PhysicalComponent):
                return PhysicalComponents[id] as T?;
            case Type t when t == typeof(CompositionComponent):
                return CompositionComponents[id] as T?;
            default:
                return default;
        }
    }
}