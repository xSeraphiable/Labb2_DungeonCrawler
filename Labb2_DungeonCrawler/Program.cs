
using System.Data;
using Labb2_DungeonCrawler;

Console.Title = "Ame's DC";

Console.WriteLine("Detta är mitt Dungeon Crawler-spel");


Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");
Console.WriteLine(Directory.GetCurrentDirectory());

Console.CursorVisible = false;
var levelOne = new LevelData();
levelOne.Load("Level1.txt");

var myPlayer = new Player(levelOne.PlayerStartingX, levelOne.PlayerStartingY);

Console.Clear();
foreach (var element in levelOne.Elements)
{
    element.Draw();
}

myPlayer.Draw();

while (true)
{
    int oldx = myPlayer.x;
    int oldy = myPlayer.y;

    if (Console.KeyAvailable)
    {

        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.UpArrow)
        {
            myPlayer.y--;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            myPlayer.y++;
        }
        else if (key.Key == ConsoleKey.RightArrow)
        {
            myPlayer.x++;
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            myPlayer.x--;
        }
        else if (key.Key == ConsoleKey.Escape)
        {

            Console.WriteLine("\nSpelet avslutas");
            break;
        }

        Position.IsPlayerInsideLevel(myPlayer, levelOne.Elements, oldx, oldy);


        Console.SetCursorPosition(oldx, oldy);
        Console.Write(' ');
        Console.SetCursorPosition(myPlayer.x, myPlayer.y);
        Console.Write('@');

        foreach (var element in levelOne.Elements)
        {
            if (element is Enemy enemy)
            {
                enemy.Update(levelOne.Elements);
                enemy.Draw();
            }
        }

    }

}


