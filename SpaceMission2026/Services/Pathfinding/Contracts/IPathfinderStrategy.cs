using SpaceMission2026.Core.Models;

namespace SpaceMission2026.Services.Pathfinding.Contracts;

/// <summary>
/// Defines a strategy for finding the shortest path on a cosmic map.
/// </summary>
public interface IPathfinderStrategy
{
    /// <summary>
    /// Calculates the optimal shortest route from the astronaut's location to the destination.
    /// </summary>
    /// <param name="map">The cosmic navigation map.</param>
    /// <param name="astronaut">The astronaut to rescue.</param>
    /// <param name="destination">The coordinates of the Space Station.</param>
    void FindShortestPath(CosmicMap map, Astronaut astronaut, Position destination);
}