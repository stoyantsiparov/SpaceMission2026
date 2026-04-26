using SpaceMission2026.Core.Enums;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.Pathfinding.Contracts;

namespace SpaceMission2026.Services.Pathfinding;

public class OptimalPathfinder : IPathfinderStrategy
{
    private readonly (int rowOffset, int colOffset)[] _directions =
    {
        (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1)
    };

    /// <inheritdoc />
    public void FindShortestPath(CosmicMap map, Astronaut astronaut, Position destination)
    {
        var distances = new Dictionary<Position, int>();
        var previousSteps = new Dictionary<Position, Position?>();
        var priorityQueue = new PriorityQueue<Position, int>();

        for (int r = 0; r < map.Rows; r++)
        {
            for (int c = 0; c < map.Cols; c++)
            {
                distances[new Position(r, c)] = int.MaxValue;
            }
        }

        var start = astronaut.StartPosition;
        distances[start] = 0;
        priorityQueue.Enqueue(start, 0);
        previousSteps[start] = null;

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();

            if (current == destination)
            {
                break;
            }

            foreach (var dir in _directions)
            {
                int newRow = current.Row + dir.rowOffset;
                int newCol = current.Col + dir.colOffset;

                if (!map.IsValidPosition(newRow, newCol)) continue;

                var neighbor = new Position(newRow, newCol);
                var cellType = map.Grid[newRow, newCol];

                if (cellType == CellType.Asteroid) continue;

                int moveCost = cellType == CellType.Debris ? 2 : 1;
                int newDistance = distances[current] + moveCost;

                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    previousSteps[neighbor] = current;
                    priorityQueue.Enqueue(neighbor, newDistance);
                }
            }
        }

        BuildPath(astronaut, destination, previousSteps, distances);
    }

    private void BuildPath(Astronaut astronaut, Position destination, Dictionary<Position, Position?> previousSteps, Dictionary<Position, int> distances)
    {
        if (distances[destination] == int.MaxValue)
        {
            astronaut.PathToStation = null;
            return;
        }

        var path = new List<Position>();
        var current = destination;

        while (previousSteps.ContainsKey(current) && previousSteps[current] != null)
        {
            path.Add(current);
            current = previousSteps[current]!.Value;
        }

        path.Reverse();
        astronaut.PathToStation = path;
        astronaut.TotalPathCost = distances[destination];
    }
}