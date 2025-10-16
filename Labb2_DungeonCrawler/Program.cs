
using System.Data;

Console.Title = "Ame's DC";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");

ConsoleColor gamecolor = ConsoleColor.DarkYellow;

Console.CursorVisible = false;
Console.ForegroundColor = gamecolor;
Console.WriteLine("DUNGEON CRAWLER");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\n  [1] Start Game");
Console.WriteLine("  [2] Instructions");
Console.WriteLine("  [3] Quit");

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

        GameLoop.PrintTextCharByChar($"Loading level...", 40);
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
        Console.WriteLine("\n  - Move with [Arrow Keys] or [W A S D]");
        Console.WriteLine("  - Explore the tunnels and survive.");
        Console.WriteLine("  - Attack enemies by moving into them.");
        Console.WriteLine("  - Watch your health bar — when it reaches zero, it’s GAME OVER.");
        Console.WriteLine("  - Some enemies fight back...");
        Console.WriteLine("  - ... and there might not be a way out - except death or ESCape...");
        Console.WriteLine("\nPress [Enter] to return to the menu.");

        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        Console.Clear();
        Console.ForegroundColor = gamecolor;
        Console.WriteLine("DUNGEON CRAWLER");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n  [1] Start Game");
        Console.WriteLine("  [2] Instructions");
        Console.WriteLine("  [3] Quit");
    }
    else if (key == ConsoleKey.D3)
    {
        GameLoop.PrintTextCharByChar("Goodbye!", 40);
        Environment.Exit(0);
    }

} while (true);


static void GameOver()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.SetCursorPosition(10, 15);

    GameLoop.PrintTextCharByChar("GAME OVER", 200);

    Console.ResetColor();

    Console.ReadLine();


}

static string GetPlayerName()
{
    string playerName;
    int maxLength = 20;

    while (true)
    {
        Console.CursorVisible = true;
        GameLoop.PrintTextCharByChar("Enter player name (max 20 chars): ", 40);
        playerName = Console.ReadLine();
        Console.CursorVisible = false;

        if (!string.IsNullOrWhiteSpace(playerName) && playerName.Length <= maxLength)
        {
            break;
        }
        Console.WriteLine($"Name must be 1-{maxLength} characters long. Try again.\n");


    }

    return playerName;

}




