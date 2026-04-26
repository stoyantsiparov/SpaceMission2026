namespace SpaceMission2026.Core.Enums;

/// <summary>
/// Represents the different types of cosmic environments present on the navigation map.
/// </summary>
public enum CellType
{
    /// <summary>
    /// Open space, safe to travel through. Cost: 1 step.
    /// </summary>
    OpenSpace,

    /// <summary>
    /// Asteroid, dangerous and impassable.
    /// </summary>
    Asteroid,

    /// <summary>
    /// Space debris, passable but incurs a higher movement cost. Cost: 2 steps.
    /// </summary>
    Debris,

    /// <summary>
    /// The Space Station, representing the final destination.
    /// </summary>
    SpaceStation,

    /// <summary>
    /// The starting location of an astronaut.
    /// </summary>
    Astronaut
}