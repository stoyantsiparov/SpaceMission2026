using SpaceMission2026.Common;
using SpaceMission2026.Core.Enums;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.MapManagement.Contracts;

namespace SpaceMission2026.Services.MapManagement;

public class MapParser : IMapParser
{
    /// <inheritdoc />
    public CosmicMap Parse(int rows, int cols, string[] gridLines)
    {
        var map = new CosmicMap(rows, cols);

        for (int r = 0; r < rows; r++)
        {
            var symbols = gridLines[r].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (symbols.Length != cols)
            {
                throw new ArgumentException(string.Format(AppMessages.InvalidColumnsInRow, r, cols));
            }

            for (int c = 0; c < cols; c++)
            {
                var symbol = symbols[c].Trim().ToUpper();
                map.Grid[r, c] = DetermineCellType(symbol);

                if (symbol.StartsWith(AppConstants.SymbolAstronautPrefix))
                {
                    map.Astronauts.Add(new Astronaut(symbol, new Position(r, c)));
                }
                else if (symbol == AppConstants.SymbolSpaceStation)
                {
                    map.SpaceStation = new Position(r, c);
                }
            }
        }

        if (map.Astronauts.Count == 0 || map.Astronauts.Count > 3)
        {
            throw new InvalidOperationException(AppMessages.InvalidAstronautCount);
        }

        return map;
    }

    private CellType DetermineCellType(string symbol)
    {
        return symbol switch
        {
            AppConstants.SymbolOpenSpace or AppConstants.SymbolOpenSpaceAlt => CellType.OpenSpace,
            AppConstants.SymbolAsteroid => CellType.Asteroid,
            AppConstants.SymbolDebris => CellType.Debris,
            AppConstants.SymbolSpaceStation => CellType.SpaceStation,
            _ when symbol.StartsWith(AppConstants.SymbolAstronautPrefix) => CellType.Astronaut,
            _ => throw new ArgumentException(string.Format(AppMessages.UnknownCosmicSymbol, symbol))
        };
    }
}