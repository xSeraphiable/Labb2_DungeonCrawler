
using System.Data;
using Labb2_DungeonCrawler;

Console.Title = "Ame's DC";

Console.WriteLine("Detta är mitt Dungeon Crawler-spel");


Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");
Console.WriteLine(Directory.GetCurrentDirectory());


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
                enemy.Update(); 
                //Jag vill göra Update i Rat-klassen men mitt problem är att jag inte fattar
                //hur jag kollar om nya positionen är ledig eller inte.
                //Måste väl vara ordningen 1. Random position 2. Kolla om random är ledig 3.1 Om nej så stanna kvar
                //3.2 Om ja så sudda ut gammal position och uppdatera till ny position. Måla ut ny posotion.


                enemy.Draw();
            }
        }

    }

}


