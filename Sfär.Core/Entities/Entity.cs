using Sfär.Core.Components;
using Sfär.Core.Interfaces;
using Sfär.Core.Registers;

namespace Sfär.Core.Entities;
public class Entity
{
    public Entity(int id)
    {
        Id = id;
        Components = new IDataComponent[GlobalSettings.MaxComponents]; 
    }

    public int Id { get; }
    public IDataComponent[] Components { get; } 
    
    public void AddComponent<T>(T component) where T : IDataComponent
    {
        var id = ComponentRegistry.GetId<T>();
        if(Components[id] != null) return;
        
        ComponentRegistry.AddToComponentMap<T>(Id);
        Components[id] = component;
    }

    public T GetComponent<T>() where T : IDataComponent
    {
        var id = ComponentRegistry.GetId<T>();
        return (T)Components[id];
    }

    public bool HasComponent<T>() where T : IDataComponent
    {
        var id = ComponentRegistry.GetId<T>();
        return Components[id] != null;
    }

    public void SetComponent<T>(T component) where T : IDataComponent
    {
        var id = ComponentRegistry.GetId<T>();
        Components[id] = component;
    }
}