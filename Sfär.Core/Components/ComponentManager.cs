using System.ComponentModel;
using Sfär.Core.Entities;

namespace Sfär.Core.Components;

public static class ComponentManager
{
    static SpatialData[] SpatialComponents = new SpatialData[GlobalSettings.MaxEntities];
    static CelestialBodyData[] PhysicalComponents = new CelestialBodyData[GlobalSettings.MaxEntities];
    static CompositionComponent[]  CompositionComponents = new CompositionComponent[GlobalSettings.MaxEntities];
    static OrbitData[] OrbitComponents = new OrbitData[GlobalSettings.MaxEntities];

    //Extension to Ientities
    public static void AddComponent<T>(this IEntity entity, T component) where T : IComponent
    {
        switch (component)
        {
            case SpatialData spatialComponent:
                SpatialComponents[entity.Id] = spatialComponent;
                break;
            case CelestialBodyData physicalProperty:
                PhysicalComponents[entity.Id] = physicalProperty;
                break;
            case CompositionComponent compositionComponent:
                CompositionComponents[entity.Id] = compositionComponent;
                break;
            case OrbitData orbitComponent:
                OrbitComponents[entity.Id] = orbitComponent;
                break;
        }
    }

    public static void RemoveComponent<T>(this IEntity entity) where T : struct, IComponent
    {
        
        if(!TryGetComponent<T>(entity.Id, out var component)) return;

        switch (typeof(T))
        {
            case Type t when t == typeof(SpatialData):
                SpatialComponents[entity.Id] = default;
                break;
            case Type t when t == typeof(CelestialBodyData):
                PhysicalComponents[entity.Id] = default;
                break;
            case Type t when t == typeof(CompositionComponent):
                CompositionComponents[entity.Id] = default;
                break;
            case Type t when t == typeof(OrbitData):
                OrbitComponents[entity.Id] = default;
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
            case Type t when t == typeof(SpatialData):
                return SpatialComponents[id] as T?;
            case Type t when t == typeof(CelestialBodyData):
                return PhysicalComponents[id] as T?;
            case Type t when t == typeof(CompositionComponent):
                return CompositionComponents[id] as T?;
            case Type t when t == typeof(OrbitData):
                return OrbitComponents[id] as T?;
            default:
                return default;
        }
    }
}