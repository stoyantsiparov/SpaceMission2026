namespace SpaceMission2026.Core.Models;

/// <summary>
/// Represents a 2D coordinate on the cosmic map.
/// </summary>
/// <param name="Row">The zero-based row index.</param>
/// <param name="Col">The zero-based column index.</param>
public readonly record struct Position(int Row, int Col);