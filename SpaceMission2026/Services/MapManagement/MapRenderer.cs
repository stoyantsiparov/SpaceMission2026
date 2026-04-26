using SpaceMission2026.Common;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.MapManagement.Contracts;

namespace SpaceMission2026.Services.MapManagement;

public class MapRenderer : IMapRenderer
{
    /// <inheritdoc />
    public void RenderInitialMap(CosmicMap map)
    {
        for (var r = 0; r < map.Rows; r++)
        {
            for (var c = 0; c < map.Cols; c++)
            {
                var currentPos = new Position(r, c);

                if (currentPos == map.SpaceStation)
                {
                    Console.Write($"{AppConstants.SymbolSpaceStation} ");
                }
                else
                {
                    var astronaut = map.Astronauts.FirstOrDefault(a => a.StartPosition == currentPos);
                    if (astronaut != null)
                    {
                        Console.Write($"{astronaut.Id} ");
                    }
                    else
                    {
                        var cellSymbol = map.Grid[r, c] switch
                        {
                            Core.Enums.CellType.Asteroid => AppConstants.SymbolAsteroid,
                            Core.Enums.CellType.Debris => AppConstants.SymbolDebris,
                            Core.Enums.CellType.OpenSpace => AppConstants.SymbolOpenSpace,
                            _ => AppConstants.SymbolUnknown
                        };
                        Console.Write($"{cellSymbol} ");
                    }
                }
            }
            Console.WriteLine();
        }
    }

    /// <inheritdoc />
    public void RenderResults(CosmicMap map, IEnumerable<Astronaut> astronauts)
    {
        var failedMissions = astronauts.Where(a => !a.IsRescued).ToList();
        var successfulMissions = astronauts
            .Where(a => a.IsRescued)
            .OrderBy(a => a.TotalPathCost)
            .ToList();

        foreach (var failedAstronaut in failedMissions)
        {
            Console.WriteLine(string.Format(AppMessages.MissionFailed, failedAstronaut.Id));
        }

        if (failedMissions.Any() && successfulMissions.Any())
        {
            Console.WriteLine(new string('-', 30));
        }

        foreach (var astronaut in successfulMissions)
        {
            Console.WriteLine(string.Format(AppMessages.MissionSuccess, astronaut.Id, astronaut.TotalPathCost));
            RenderMapWithPath(map, astronaut);
            Console.WriteLine();
        }
    }

    private void RenderMapWithPath(CosmicMap map, Astronaut astronaut)
    {
        var pathSet = astronaut.PathToStation?.ToHashSet() ?? new HashSet<Position>();

        for (var r = 0; r < map.Rows; r++)
        {
            for (var c = 0; c < map.Cols; c++)
            {
                var currentPos = new Position(r, c);

                if (currentPos == astronaut.StartPosition)
                {
                    Console.Write($"{astronaut.Id} ");
                }
                else if (currentPos == map.SpaceStation)
                {
                    Console.Write($"{AppConstants.SymbolSpaceStation} ");
                }
                else if (pathSet.Contains(currentPos))
                {
                    Console.Write($"{AppConstants.SymbolPath} ");
                }
                else
                {
                    var otherAstronaut = map.Astronauts.FirstOrDefault(a => a.StartPosition == currentPos);
                    if (otherAstronaut != null)
                    {
                        Console.Write($"{otherAstronaut.Id} ");
                    }
                    else
                    {
                        var cellSymbol = map.Grid[r, c] switch
                        {
                            Core.Enums.CellType.Asteroid => AppConstants.SymbolAsteroid,
                            Core.Enums.CellType.Debris => AppConstants.SymbolDebris,
                            Core.Enums.CellType.OpenSpace => AppConstants.SymbolOpenSpace,
                            _ => AppConstants.SymbolUnknown
                        };
                        Console.Write($"{cellSymbol} ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}