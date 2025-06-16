using System.Reflection;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Managers;

public static class ComponentManager
{
    private static readonly ComponentMap[] ComponentMaps = new ComponentMap[GlobalSettings.MaxComponents];
    public static void RegisterComponents()
    {
        var componentTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t =>
                t is { IsValueType: true, IsEnum: false, Namespace: "Sfär.Core.Components" });

        var i = 0;
        foreach (var componentType in componentTypes)
            try
            {
                if (!typeof(IDataComponent).IsAssignableFrom(componentType)) continue;
                ComponentMaps[i] = new ComponentMap(componentType);
                i++;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add component {componentType.FullName} to Components");
            }
    }
    public static int GetId<T>()
    {
        for (int i = 0; i < ComponentMaps.Length; i++)
        {
            if (ComponentMaps[i].ComponentType == typeof(T))
                return i;
        }

        return null;
    }

    public static void AddToComponentMap<T>(int entityId)
    {
        ComponentMaps[GetId<T>()].AddUsage(entityId);
    }

    public static ReadOnlySpan<int> GetEntityIdsFor<T>()
    {
        return ComponentMaps[GetId<T>()].GetUsageIds;
    }
}