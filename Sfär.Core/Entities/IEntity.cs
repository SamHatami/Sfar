namespace Sfär.Core.Entities;

public interface IEntity
{
    int Id { get; }
    string Label { get; set; }
}