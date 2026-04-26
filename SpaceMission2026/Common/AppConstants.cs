namespace SpaceMission2026.Common;

/// <summary>
/// Contains globally used constant values, including map symbols and expected user inputs.
/// </summary>
public static class AppConstants
{
    // Cosmic Map Symbols
    public const string SymbolOpenSpace = "0";
    public const string SymbolOpenSpaceAlt = "O";
    public const string SymbolAsteroid = "X";
    public const string SymbolDebris = "D";
    public const string SymbolSpaceStation = "F";
    public const string SymbolAstronautPrefix = "S";
    public const string SymbolPath = "*";
    public const string SymbolUnknown = "?";

    // CLI Input Modes & Options
    public const string InputYes = "y";
    public const string ModeManual = "1";
    public const string ModeDynamic = "2";

    // Map minimum and maximum size
    public const int MinMapSize = 2;
    public const int MaxMapSize = 100;
}