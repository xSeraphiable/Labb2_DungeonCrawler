
using System.Data;

Console.Title = "Ame's DC";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");

var currentLevel = new LevelData();

string level = "Level1.txt";
currentLevel.Load(level);

var myPlayer = new Player(currentLevel.PlayerStartingX, currentLevel.PlayerStartingY);

Console.CursorVisible = false;
Console.Clear();

GameLoop.Run(currentLevel, myPlayer);

GameOver();

static void GameOver()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.SetCursorPosition(10, 15);

    string gameover = "GAME OVER";

    foreach (char c in gameover)
    {
        Thread.Sleep(200);
        Console.Write(c);
    }

    Console.ResetColor();

    Console.ReadLine();


}


