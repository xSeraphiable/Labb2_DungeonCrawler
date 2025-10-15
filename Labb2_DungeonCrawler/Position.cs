using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

static class Position
{
    public static bool IsAvailable(IReadOnlyList<LevelElement> Elements, int x, int y) //TODO: kan jag använda retur av objekt här precis som för spelaren?
    {
        foreach (LevelElement element in Elements)
        {
            if (element.x == x && element.y == y)
            {
                return false;
            }
        }
        return true;
    }
    public static bool IsPlayerAtPosition(Player p, int x, int y)
    {
        return (x, y) == (p.x, p.y);

    }

    public static int CalculateDistance(int x, int y, int a, int b)
    {
        return (int)Math.Round(Math.Sqrt(((b - y) * (b - y)) + ((a - x) * (a - x))));
    }

    //TODO: Du kan även låta den returnera en bas-klass (t.ex. LevelElement),
    //och sedan låta den som anropar avgöra vad det är för något.
    //Då kan metoden heta t.ex.GetCollidingElement() — mer generiskt och flexibelt.
    public static Enemy CheckCollisionAndReturnEnemy(Player p, IReadOnlyList<LevelElement> Elements)
    {
        foreach (var element in Elements)
        {
            if (element.x == p.x && element.y == p.y)
            {
                if (element is Wall)
                {
                    p.x = p.OldX;
                    p.y = p.OldY;
                    return null;
                }

                else if (element is Rat)
                {
                    p.x = p.OldX;
                    p.y = p.OldY;
                    return (Rat)element;
                }

                else if (element is Snake)
                {
                    p.x = p.OldX;
                    p.y = p.OldY;
                    return ((Snake)element);
                }
            }
        }

        return null;
    }


    public static void SetCursorAndWipeEntireRow(int r, int c)
    {
        Thread.Sleep(500);
        Console.SetCursorPosition(r, c);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(r, c);

    }

}

