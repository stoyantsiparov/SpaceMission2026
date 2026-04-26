using SpaceMission2026.Core.Models;

namespace SpaceMission2026.Services.MapManagement.Contracts;

/// <summary>
/// Defines the contract for visualizing the map and reporting mission results.
/// </summary>
public interface IMapRenderer
{
    /// <summary>
    /// Renders the initial state of the cosmic map before any pathfinding has occurred.
    /// </summary>
    /// <param name="map">The map to render.</param>
    void RenderInitialMap(CosmicMap map);

    /// <summary>
    /// Renders the mission results to the console, prioritizing failed missions first, 
    /// followed by successful missions sorted by the shortest path length.
    /// </summary>
    /// <param name="map">The original cosmic map.</param>
    /// <param name="astronauts">The list of astronauts with their calculated paths.</param>
    void RenderResults(CosmicMap map, IEnumerable<Astronaut> astronauts);
}