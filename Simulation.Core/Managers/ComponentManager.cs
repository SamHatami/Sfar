using System.Reflection;
using Simulation.Core.Components;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Managers;

public static class ComponentManager
{
    private static readonly ComponentMap[] ComponentMaps = new ComponentMap[GlobalSettings.MaxComponents];
    private static readonly Dictionary<Type,int> ComponentIdsCache = new(GlobalSettings.MaxComponents);
    public static void RegisterComponents()
    {
        Span<Type> componentTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t =>
                t is { IsValueType: true, IsEnum: false, Namespace: "Simulation.Core.Components" }).ToArray();

        var i = 0;
        foreach (var componentType in componentTypes)
            try
            {
                if (!typeof(IDataComponent).IsAssignableFrom(componentType)) continue;
                ComponentMaps[i] = new ComponentMap(componentType);
                ComponentIdsCache[componentType] = i;
                i++;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add component {componentType.FullName} to Components");
            }
    }
    public static void AddToComponentMap<T>(int entityId)
    {
        ComponentMaps[GetId<T>()].AddUsage(entityId);
    }
    public static int GetId<T>() => ComponentIdsCache[typeof(T)];
    public static ReadOnlySpan<int> GetEntityIdsFor<T>() => ComponentMaps[GetId<T>()].GetUsageIds();
    
}