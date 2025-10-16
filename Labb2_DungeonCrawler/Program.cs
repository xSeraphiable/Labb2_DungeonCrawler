
using System.Data;
using System.Globalization;

Console.Title = "Dungeon Crawler 0.2";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");

ConsoleColor gamecolor = ConsoleColor.DarkYellow;

Console.CursorVisible = false;
Console.ForegroundColor = gamecolor;
Console.WriteLine("DUNGEON CRAWLER");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(
           "\n  [1] Start Game" +
           "\n  [2] Instructions" +
           "\n  [3] Quit");

ConsoleKey key;
do
{
    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.D1)
    {
        Console.Clear();

        string playerName = GetPlayerName();

        var level = new LevelData();
        level.Load("Level1.txt");

        var player = new Player(level.PlayerStartingX, level.PlayerStartingY, playerName);

        GameLoop.PrintTextCharByChar($"\nLoading level...", 40);
        Thread.Sleep(600);
        Console.Clear();

        GameLoop.Run(level, player);
        if (!player.IsAlive) { GameOver(); }
        else { Environment.Exit(0); }
    }
    else if (key == ConsoleKey.D2)
    {
        Console.Clear();
        Console.ForegroundColor = gamecolor;
        Console.WriteLine("INSTRUCTIONS");
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
        Console.ForegroundColor = gamecolor;
        Console.WriteLine("DUNGEON CRAWLER");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "\n  [1] Start Game" +
            "\n  [2] Instructions" +
            "\n  [3] Quit");
    }
    else if (key == ConsoleKey.D3 || key == ConsoleKey.Escape)
    {
        GameLoop.PrintTextCharByChar("Goodbye!", 40);
        Environment.Exit(0);
    }

} while (true);


static void GameOver()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    GameLoop.PrintTextCharByChar("GAME OVER", 200);

    Console.ResetColor();

}

static string GetPlayerName()
{
    string playerName;
    int maxLength = 15;

    while (true)
    {
        Console.CursorVisible = true;
        GameLoop.PrintTextCharByChar($"Enter player name (max {maxLength} chars): ", 40);
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




