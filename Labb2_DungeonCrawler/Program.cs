
using System.Data;
using Labb2_DungeonCrawler;

Console.Title = "Ame's DC";

Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");


var currentLevel = new LevelData();
currentLevel.Load("Level1.txt");

var myPlayer = new Player(currentLevel.PlayerStartingX, currentLevel.PlayerStartingY);

//Console.Write("Enter name: ");
//myPlayer.Name = Console.ReadLine();

//Console.WriteLine("Welcome " + myPlayer.Name);
//Thread.Sleep(1000);
//
//Console.WriteLine("Loading level");

//Thread.Sleep(2000);
Console.CursorVisible = false;
Console.Clear();

foreach (var element in currentLevel.Elements)
{
    if (element is Wall && (Position.CalculateDistance(element.x, element.y, myPlayer.x, myPlayer.y) <= 5))
    {
        element.Draw();
    }
}

myPlayer.Draw();

int rounds = 0;
while (true)
{

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"|||   Player: {myPlayer.Name}  |  Current health: {myPlayer.Health}  |  Rounds: {rounds}  |||");
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

    var target = Position.CheckCollisionAndReturnEnemy(myPlayer, currentLevel.Elements);

    if (target != null)
    {
        Player.Attack(myPlayer, target);
        if (target.Health <= 0)
        {
            target.Update(currentLevel.Elements, myPlayer); //TODO: detta verkar bugga lite. se över.
            currentLevel.Delete(target);
        }
    }

    Console.SetCursorPosition(myPlayer.OldX, myPlayer.OldY);
    Console.Write(' ');
    myPlayer.Draw();

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

    rounds++; //TODO: behöver ändra så rounds bara uppdateras när spelaren rör på sig.

}


