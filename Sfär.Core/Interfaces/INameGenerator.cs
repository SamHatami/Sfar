using Sfär.Core.Entities;

namespace Sfär.Core.Interfaces;

public interface INameGenerator
{
    void CreateAndSetNames(Entity[] entities);
}