
using System.Data;
using System.Drawing;
using System.Globalization;


ConfigureConsole();
PrintMenu();

ConsoleKey key;
do
{
    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.D1)
    {
        Console.Clear();

        var level = new LevelData();
        level.Load(Path.Combine("Levels", "Level1.txt"));

        string playerName = GetPlayerName();
        var player = new Player(level.PlayerStartingX, level.PlayerStartingY, playerName);

        TextDisplay.PrintTextCharByChar($"\nLoading level...", 40);
        Thread.Sleep(600);
        Console.Clear();

        GameLoop.Run(level, player);

        if (!player.IsAlive) { GameOver(); }
        else { Environment.Exit(0); }
    }
    else if (key == ConsoleKey.D2)
    {
        Console.Clear();

        PrintHeader("INSTRUCTIONS");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(
            "\n  - Move with [Arrow Keys] or [W A S D]" +
            "\n  - Explore the tunnels and survive." +
            "\n  - Attack enemies by moving into them." +
            "\n  - Watch your health bar — when it reaches zero, it’s GAME OVER." +
            "\n  - Some enemies fight back..." +
            "\n  - ... and there might not be a way out - except death or ESCape..." +
            "\n\nPress [Enter] to return to the menu.");

        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

        Console.Clear();
        PrintMenu();

    }
    else if (key == ConsoleKey.D3 || key == ConsoleKey.Escape)
    {
        TextDisplay.PrintTextCharByChar("Goodbye!", 40);
        Environment.Exit(0);
    }

} while (true);

static void PrintHeader(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void PrintMenu()
{
    PrintHeader("DUNGEON CRAWLER");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(
               "\n  [1] Start Game" +
               "\n  [2] Instructions" +
               "\n  [3] Quit");

}
static void ConfigureConsole()
{
    Console.Title = "Dungeon Crawler 0.2";
    Console.CursorVisible = false;
}

static void GameOver()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    TextDisplay.PrintTextCharByChar("GAME OVER", 200);

    Console.ResetColor();
}

static string GetPlayerName()
{
    string? playerName;
    int maxLength = 15;

    while (true)
    {
        Console.CursorVisible = true;
        TextDisplay.PrintTextCharByChar($"Enter player name (max {maxLength} chars): ", 40);
        playerName = Console.ReadLine();
        Console.CursorVisible = false;

        if (!string.IsNullOrWhiteSpace(playerName) && playerName.Length <= maxLength)
        {
            break;
        }
        Console.WriteLine($"Name must be 1-{maxLength} characters long. Try again.\n");
    }

    TextInfo myTI = new CultureInfo("sv-SE", false).TextInfo;
    return myTI.ToTitleCase(playerName);

}





