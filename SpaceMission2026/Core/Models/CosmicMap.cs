using SpaceMission2026.Core.Enums;

namespace SpaceMission2026.Core.Models;

/// <summary>
/// Represents the cosmic environment, holding the grid data and the entities within it.
/// </summary>
public class CosmicMap
{
    /// <summary>Total number of rows in the map.</summary>
    public int Rows { get; }

    /// <summary>Total number of columns in the map.</summary>
    public int Cols { get; }

    /// <summary>The 2D grid representing the cosmic environment.</summary>
    public CellType[,] Grid { get; }

    /// <summary>The list of astronauts stranded on the map.</summary>
    public List<Astronaut> Astronauts { get; } = new();

    /// <summary>The coordinates of the Space Station.</summary>
    public Position SpaceStation { get; set; }

    public CosmicMap(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Grid = new CellType[rows, cols];
    }

    /// <summary>
    /// Checks if the specified coordinates are within the boundaries of the map.
    /// </summary>
    public bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < Rows && col >= 0 && col < Cols;
    }
}