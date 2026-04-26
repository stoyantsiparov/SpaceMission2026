using SpaceMission2026.Core.Models;

namespace SpaceMission2026.Services.MapManagement.Contracts;

/// <summary>
/// Defines the contract for dynamically generating a random cosmic navigation map.
/// </summary>
public interface IMapGenerator
{
    /// <summary>
    /// Generates a valid cosmic map with randomly placed entities and obstacles.
    /// </summary>
    /// <param name="rows">The number of rows.</param>
    /// <param name="cols">The number of columns.</param>
    /// <param name="asteroidCount">The number of impassable asteroids.</param>
    /// <param name="debrisCount">The number of space debris fields.</param>
    /// <param name="astronautCount">The number of stranded astronauts (1 to 3).</param>
    /// <returns>A fully populated CosmicMap instance.</returns>
    CosmicMap Generate(int rows, int cols, int asteroidCount, int debrisCount, int astronautCount);
}