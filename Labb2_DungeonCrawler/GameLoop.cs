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
            if (key.Key == ConsoleKey.UpArrow)
            {
                myPlayer.y--;
                rounds++;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                myPlayer.y++;
                rounds++;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                myPlayer.x++;
                rounds++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
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
                    target.Update(currentLevel.Elements, myPlayer);
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
        Console.WriteLine($"{attacker.Name} attacks {defender.Name} and deals {damage} damage.");
        Console.ResetColor();

        defender.TakeDamage(damage);

        Thread.Sleep(1500);
        Position.SetCursorAndWipeEntireRow(0, 3);
        //Thread.Sleep(1000);
        Position.SetCursorAndWipeEntireRow(0, 4);
    }


    static void PrintStats(string name, int health, int rounds)
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