namespace Sfär.Core.Entities;

public struct Entity : IEntity
{
    public int Id { get; }
    public string Label { get; set; }

    public Entity(int id)
    {
        Id = id;
    }
}