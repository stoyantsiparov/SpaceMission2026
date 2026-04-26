using SpaceMission2026.Core.Models;

namespace SpaceMission2026.Services.MapManagement.Contracts;

/// <summary>
/// Defines the contract for transforming raw text input into a structured cosmic map.
/// </summary>
public interface IMapParser
{
    /// <summary>
    /// Parses the raw string input from the console into a navigable cosmic map.
    /// Extracts astronaut starting positions and the Space Station location.
    /// </summary>
    /// <param name="rows">Total number of rows.</param>
    /// <param name="cols">Total number of columns.</param>
    /// <param name="gridLines">The raw string representation of the grid rows.</param>
    /// <returns>A fully populated CosmicMap instance.</returns>
    /// <exception cref="ArgumentException">Thrown when a row has an invalid number of columns or contains an unknown symbol.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the map does not contain between 1 and 3 astronauts.</exception>
    CosmicMap Parse(int rows, int cols, string[] gridLines);
}