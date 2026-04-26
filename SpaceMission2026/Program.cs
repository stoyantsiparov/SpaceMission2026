using Microsoft.Extensions.DependencyInjection;
using SpaceMission2026.Common;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.MapManagement;
using SpaceMission2026.Services.MapManagement.Contracts;
using SpaceMission2026.Services.Notifications;
using SpaceMission2026.Services.Notifications.Contracts;
using SpaceMission2026.Services.Pathfinding;
using SpaceMission2026.Services.Pathfinding.Contracts;

// 1. Dependency Injection Setup
var services = new ServiceCollection();
services.AddSingleton<IMapParser, MapParser>();
services.AddSingleton<IMapRenderer, MapRenderer>();
services.AddSingleton<IMapGenerator, MapGenerator>();
services.AddTransient<IPathfinderStrategy, OptimalPathfinder>();
services.AddSingleton<IEmailService, SmtpEmailService>();

var serviceProvider = services.BuildServiceProvider();

var parser = serviceProvider.GetRequiredService<IMapParser>();
var renderer = serviceProvider.GetRequiredService<IMapRenderer>();
var generator = serviceProvider.GetRequiredService<IMapGenerator>();
var pathfinder = serviceProvider.GetRequiredService<IPathfinderStrategy>();
var emailService = serviceProvider.GetRequiredService<IEmailService>();

try
{
    Console.WriteLine(AppMessages.MenuHeader);
    Console.WriteLine(AppMessages.MenuOption1);
    Console.WriteLine(AppMessages.MenuOption2);
    Console.Write(AppMessages.PromptInitMode);
    var mode = Console.ReadLine()?.Trim();

    CosmicMap map;

    if (mode == AppConstants.ModeDynamic)
    {
        Console.Write(AppMessages.PromptRows);
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows < AppConstants.MinMapSize || rows > AppConstants.MaxMapSize)
            throw new ArgumentException(AppMessages.ErrorInvalidMapSize);

        Console.Write(AppMessages.PromptCols);
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols < AppConstants.MinMapSize || cols > AppConstants.MaxMapSize)
            throw new ArgumentException(AppMessages.ErrorInvalidMapSize);

        Console.Write(AppMessages.PromptAsteroids);
        int asteroids = int.Parse(Console.ReadLine()!);
        Console.Write(AppMessages.PromptDebris);
        int debris = int.Parse(Console.ReadLine()!);
        Console.Write(AppMessages.PromptAstronauts);
        int astronauts = int.Parse(Console.ReadLine()!);

        map = generator.Generate(rows, cols, asteroids, debris, astronauts);
        Console.WriteLine(AppMessages.GeneratedMapHeader);
        renderer.RenderInitialMap(map);
    }
    else if (mode == AppConstants.ModeManual)
    {
        Console.Write(AppMessages.PromptMapRows);
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows < AppConstants.MinMapSize || rows > AppConstants.MaxMapSize)
            throw new ArgumentException(AppMessages.ErrorInvalidMapSize);

        Console.Write(AppMessages.PromptMapCols);
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols < AppConstants.MinMapSize || cols > AppConstants.MaxMapSize)
            throw new ArgumentException(AppMessages.ErrorInvalidMapSize);

        Console.WriteLine(AppMessages.PromptEnterMap);
        var gridLines = new string[rows];
        for (int i = 0; i < rows; i++)
        {
            gridLines[i] = Console.ReadLine() ?? string.Empty;
        }

        map = parser.Parse(rows, cols, gridLines);
    }
    else
    {
        throw new ArgumentException(string.Format(AppMessages.UnknownCosmicSymbol, mode));
    }

    foreach (var astronaut in map.Astronauts)
    {
        pathfinder.FindShortestPath(map, astronaut, map.SpaceStation);
    }

    Console.WriteLine(AppMessages.MissionResultsHeader);
    renderer.RenderResults(map, map.Astronauts);

    Console.WriteLine(AppMessages.PromptSendEmail);
    var sendEmailInput = Console.ReadLine()?.Trim().ToLower();

    if (sendEmailInput == AppConstants.InputYes)
    {
        Console.Write(AppMessages.PromptSmtpHost);
        var smtpHost = Console.ReadLine() ?? AppMessages.DefaultSmtpHost;

        Console.Write(AppMessages.PromptSmtpPort);
        if (!int.TryParse(Console.ReadLine(), out int smtpPort)) smtpPort = 587;

        Console.Write(AppMessages.PromptSenderEmail);
        var sender = Console.ReadLine() ?? string.Empty;

        Console.Write(AppMessages.PromptPassword);
        var password = Console.ReadLine() ?? string.Empty;

        Console.Write(AppMessages.PromptReceiverEmail);
        var receiver = Console.ReadLine() ?? string.Empty;

        Console.WriteLine(AppMessages.TransmissionNote);
        emailService.SendReport(smtpHost, smtpPort, sender, password, receiver, map.Astronauts);
    }
}
catch (Exception ex)
{
    Console.WriteLine(string.Format(AppMessages.CriticalSystemError, ex.Message));
}