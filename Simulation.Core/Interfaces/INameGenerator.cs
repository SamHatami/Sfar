using Simulation.Core.Entities;

namespace Simulation.Core.Interfaces;

public interface INameGenerator
{
    void CreateAndSetNames(Entity[] entities);
}