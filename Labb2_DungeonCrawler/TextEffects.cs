using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class TextEffects
{
    public static void PrintTextCharByChar(string text, int delay = 20)
    {
        foreach (char c in text)
        {
            Thread.Sleep(delay);
            Console.Write(c);
        }

    }
    public static void SetCursorAndWipeEntireRow(int r, int c)
    {
        Thread.Sleep(500);
        Console.SetCursorPosition(r, c);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(r, c);

    }


}

