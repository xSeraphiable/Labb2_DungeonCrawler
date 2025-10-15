
using System.Data;


Console.Title = "Ame's DC";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");

var currentLevel = new LevelData();

//Console.WriteLine("Ange vilken level du vill köra: ");
string level = "Level1.txt";
currentLevel.Load(level);

var myPlayer = new Player(currentLevel.PlayerStartingX, currentLevel.PlayerStartingY);

Console.CursorVisible = false;
Console.Clear();

GameLoop.Run(currentLevel, myPlayer);

