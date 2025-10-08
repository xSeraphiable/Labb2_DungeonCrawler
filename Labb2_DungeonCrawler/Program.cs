
using System.Data;
using Labb2_DungeonCrawler;

Console.Title = "Ame's DC";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");
Console.WriteLine(Directory.GetCurrentDirectory());

Console.CursorVisible = false;

var currentLevel = new LevelData();
currentLevel.Load("Level1.txt");

var myPlayer = new Player(currentLevel.PlayerStartingX, currentLevel.PlayerStartingY);

Console.Clear();

foreach (var element in currentLevel.Elements)
{
    if (element is Wall && (Position.CalculateDistance(element.x, element.y, myPlayer.x, myPlayer.y) <= 5))
    {
        element.Draw();
    }
}

myPlayer.Draw();

while (true)
{
    myPlayer.OldX = myPlayer.x;
    myPlayer.OldY = myPlayer.y;

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

    //här behöver jag fånga upp fienden som returneras och använda en Attack-metod.

    Console.SetCursorPosition(0, 22);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, 20);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, 20);
    Console.WriteLine((Position.CheckCollisionAndReturnEnemy(myPlayer, currentLevel.Elements)?.EnemyName));


    Console.SetCursorPosition(myPlayer.OldX, myPlayer.OldY);
    Console.Write(' ');
    Console.SetCursorPosition(myPlayer.x, myPlayer.y);
    Console.Write('@');


    foreach (var element in currentLevel.Elements)
    {
        if (element is Enemy enemy)
        {
            enemy.Update(currentLevel.Elements, myPlayer);
            if (Position.CalculateDistance(enemy.x, enemy.y, myPlayer.x, myPlayer.y) <= 5)
            {
                enemy.Draw();
            }
        }
        if (element is Wall && (Position.CalculateDistance(element.x, element.y, myPlayer.x, myPlayer.y) <= 5))
        {
            element.Draw();

        }

    }



}


