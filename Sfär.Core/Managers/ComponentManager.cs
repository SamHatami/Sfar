using System.Reflection;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Managers;

public static class ComponentManager
{
    private static readonly Dictionary<int, List<int>> ComponentEntityMap = new();
    private static readonly Dictionary<Type, int> ComponentIds = new();

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
                ComponentIds[componentType] = i;
                i++;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add component {componentType.FullName} to Components");
            }
    }
    public static int GetId<T>() => ComponentIds[typeof(T)];

    public static void AddToComponentMap<T>(int entityId)
    {
        var componentId = GetId<T>();

        if (!ComponentEntityMap.ContainsKey(componentId))
            ComponentEntityMap.Add(componentId, new List<int>());

        var componentMask = ComponentEntityMap[componentId];
        componentMask.Add(entityId);
    }

    public static int[] GetEntityIdsFor<T>()
    {
        var componentId = GetId<T>();
        var componentMask = ComponentEntityMap[componentId];

        return componentMask.ToArray();
    }
}