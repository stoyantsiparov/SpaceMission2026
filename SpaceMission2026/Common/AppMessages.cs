namespace SpaceMission2026.Common;

/// <summary>
/// Contains all constant string messages and labels used throughout the application.
/// </summary>
public static class AppMessages
{
    public const string InvalidColumnsInRow = "Row {0} does not have exactly {1} columns.";
    public const string InvalidAstronautCount = "The map must contain between 1 and 3 astronauts.";
    public const string UnknownCosmicSymbol = "Unknown cosmic symbol: {0}";
    public const string MapTooSmall = "Map is too small to fit all requested entities.";
    public const string ErrorInvalidMapSize = "Invalid map size! Rows and columns must be between 2 and 100.";

    public const string MissionFailed = "Mission failed - Astronaut {0} lost in space!";
    public const string MissionSuccess = "Astronaut {0} - Shortest path: {1} steps";

    public const string EmailReportTitle = "SPACE 2026 Mission Report";
    public const string EmailSubject = "SPACE 2026 - Mission Results";
    public const string EmailRescuedNote = "Astronaut {0} - Rescued! Shortest path: {1} steps.";
    public const string EmailLostNote = "Astronaut {0} - Mission failed. Lost in space.";
    public const string EmailSentSuccess = "Mission report successfully sent to Mission Control!";
    public const string EmailWarning = "\nWarning: Failed to send email report. {0}";

    public const string MenuHeader = "=== SPACE 2026 Mission Control ===";
    public const string MenuOption1 = "1. Parse manual map input";
    public const string MenuOption2 = "2. Generate dynamic map";
    public const string GeneratedMapHeader = "\n--- GENERATED NAVIGATION MAP ---";
    public const string MissionResultsHeader = "\n--- MISSION RESULTS ---";
    public const string CriticalSystemError = "\nCritical System Error: {0}";

    public const string PromptInitMode = "Select initialization mode (1/2): ";
    public const string PromptRows = "Rows: ";
    public const string PromptCols = "Columns: ";
    public const string PromptAsteroids = "Number of Asteroids (X): ";
    public const string PromptDebris = "Number of Debris fields (D): ";
    public const string PromptAstronauts = "Number of Astronauts (1-3): ";
    public const string PromptMapRows = "Map rows: ";
    public const string PromptMapCols = "Map columns: ";
    public const string PromptEnterMap = "Enter map rows:";

    public const string PromptSendEmail = "\nDo you want to email the report to Mission Control? (y/n)";
    public const string PromptSmtpHost = "SMTP Host (e.g., smtp.gmail.com): ";
    public const string PromptSmtpPort = "SMTP Port (e.g., 587): ";
    public const string PromptSenderEmail = "Sender Email: ";
    public const string PromptPassword = "Password (App Password): ";
    public const string PromptReceiverEmail = "Receiver Email: ";
    public const string TransmissionNote = "Transmitting to Mission Control...";

    public const string DefaultSmtpHost = "smtp.gmail.com";
}