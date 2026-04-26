namespace SpaceMission2026.Core.Models;

/// <summary>
/// Represents the cosmic environment, holding the grid data and the entities within it.
/// </summary>
public class CosmicMap
{
    public int Rows { get; }
    public int Cols { get; }
    public CellType[,] Grid { get; }
    public List<Astronaut> Astronauts { get; } = new();
    public Position SpaceStation { get; set; }

    public CosmicMap(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Grid = new CellType[rows, cols];
    }

    public bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < Rows && col >= 0 && col < Cols;
    }
}