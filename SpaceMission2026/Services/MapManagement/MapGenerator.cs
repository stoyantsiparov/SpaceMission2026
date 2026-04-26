using SpaceMission2026.Common;
using SpaceMission2026.Core.Enums;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.MapManagement.Contracts;

namespace SpaceMission2026.Services.MapManagement;

/// <summary>
/// Implements dynamic map generation by randomly placing entities without overlapping.
/// </summary>
public class MapGenerator : IMapGenerator
{
    private readonly Random _random = new();

    /// <inheritdoc />
    public CosmicMap Generate(int rows, int cols, int asteroidCount, int debrisCount, int astronautCount)
    {
        int totalCells = rows * cols;
        int requiredCells = 1 + astronautCount + asteroidCount + debrisCount;

        if (requiredCells > totalCells)
        {
            throw new ArgumentException(AppMessages.MapTooSmall);
        }

        var map = new CosmicMap(rows, cols);
        var availablePositions = new List<Position>(totalCells);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                map.Grid[r, c] = CellType.OpenSpace;
                availablePositions.Add(new Position(r, c));
            }
        }

        Position GetRandomPosition()
        {
            int index = _random.Next(availablePositions.Count);
            var pos = availablePositions[index];
            availablePositions.RemoveAt(index);
            return pos;
        }

        var stationPos = GetRandomPosition();
        map.SpaceStation = stationPos;
        map.Grid[stationPos.Row, stationPos.Col] = CellType.SpaceStation;

        for (int i = 1; i <= astronautCount; i++)
        {
            var astroPos = GetRandomPosition();
            map.Astronauts.Add(new Astronaut($"{AppConstants.SymbolAstronautPrefix}{i}", astroPos));
            map.Grid[astroPos.Row, astroPos.Col] = CellType.Astronaut;
        }

        for (int i = 0; i < asteroidCount; i++)
        {
            var astPos = GetRandomPosition();
            map.Grid[astPos.Row, astPos.Col] = CellType.Asteroid;
        }

        for (int i = 0; i < debrisCount; i++)
        {
            var debPos = GetRandomPosition();
            map.Grid[debPos.Row, debPos.Col] = CellType.Debris;
        }

        return map;
    }
}