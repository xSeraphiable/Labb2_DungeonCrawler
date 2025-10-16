using System;

static class GameLoop
{

    public static void Run(LevelData currentLevel, Player myPlayer)
    {
        int rounds = 0;

        myPlayer.Draw();

        foreach (var element in currentLevel.Elements)
        {
            if (element is Wall && (Position.CalculateDistance(element.x, element.y, myPlayer.x, myPlayer.y) <= 5))
            {
                element.Draw();
            }
        }

        while (myPlayer.IsAlive)
        {
            PrintStats(myPlayer.Name, myPlayer.Health, rounds);

            myPlayer.OldX = myPlayer.x;
            myPlayer.OldY = myPlayer.y;

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
            {
                myPlayer.y--;
                rounds++;
            }
            else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
            {
                myPlayer.y++;
                rounds++;
            }
            else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
            {
                myPlayer.x++;
                rounds++;
            }
            else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
            {
                myPlayer.x--;
                rounds++;
            }
            else if (key.Key == ConsoleKey.Escape)
            {

                Console.WriteLine("\nSpelet avslutas");
                break;
            }

            var target = Position.CheckCollisionAndReturnEnemy(myPlayer, currentLevel.Elements);

            if (target != null)
            {
                if (target.IsAlive)
                {
                    Attack(myPlayer, target);
                }

                if (target.IsAlive)
                {
                    Attack(target, myPlayer);
                }
                else
                {
                    currentLevel.Delete(target);
                }

            }

            Console.SetCursorPosition(myPlayer.OldX, myPlayer.OldY);
            Console.Write(' ');
            myPlayer.Draw();

            UpdateMap(myPlayer, currentLevel);
        }
    }

    public static void Attack(Character attacker, Character defender)
    {
        int damage = Math.Max(attacker.AttackDice.Roll() - defender.DefenceDice.Roll(), 0);

        Position.SetCursorAndWipeEntireRow(0, 3);
        Console.ForegroundColor = attacker.Color;
        PrintTextCharByChar($"{attacker.Name} rolls their {attacker.AttackDice.ToString()} and strikes {defender.Name} dealing {damage} damage.");
        Console.ResetColor();

        defender.TakeDamage(damage);

        Thread.Sleep(1500);
        Position.SetCursorAndWipeEntireRow(0, 3);
        Position.SetCursorAndWipeEntireRow(0, 4); //TODO: den här tar bort deathmessage vid rätt tidpunkt - vilket inte är så snyggt, men har ingen bättre lösning just nu.

    }

    public static void PrintTextCharByChar(string text, int delay = 20)
    {
        foreach (char c in text)
        {
            Thread.Sleep(delay);
            Console.Write(c);
        }

    }

    static void PrintStats(string name, int health, int rounds) //TODO: borde flytta detta och allt som har med hur spelaren rör sig till spelaren?
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"|||   Player: {name}  |  Current health: {health}  |  Rounds: {rounds}  |||");
    }


    static void UpdateMap(Player myPlayer, LevelData currentLevel)
    {
        foreach (var element in currentLevel.Elements)
        {
            if (element is Enemy enemy && enemy.IsAlive)
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
}