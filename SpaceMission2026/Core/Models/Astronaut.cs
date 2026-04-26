namespace SpaceMission2026.Core.Models;

/// <summary>
/// Represents an astronaut stranded in space, maintaining their state and calculated route.
/// </summary>
public class Astronaut
{
    /// <summary>The unique identifier of the astronaut (e.g., "S1").</summary>
    public string Id { get; }

    /// <summary>The starting coordinates on the cosmic map.</summary>
    public Position StartPosition { get; }

    /// <summary>The calculated sequence of steps to reach the Space Station.</summary>
    public List<Position>? PathToStation { get; set; }

    /// <summary>The total movement cost required for the route.</summary>
    public int TotalPathCost { get; set; }

    /// <summary>Indicates whether a valid route to the Space Station was found.</summary>
    public bool IsRescued => PathToStation != null && PathToStation.Any();

    public Astronaut(string id, Position startPosition)
    {
        Id = id;
        StartPosition = startPosition;
    }
}