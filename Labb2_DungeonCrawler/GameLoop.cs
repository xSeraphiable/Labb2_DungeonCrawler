using System;

static class GameLoop
{

    public static void Run(LevelData currentLevel, Player myPlayer)
    {
        int rounds = 0;

        myPlayer.Draw();

        UpdateMap(myPlayer, currentLevel);

        while (myPlayer.IsAlive)
        {
            myPlayer.PrintStats(rounds);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Shutting down game.");
                break;
            }

            myPlayer.HandleInput(key.Key);
            rounds++;

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

        TextEffects.SetCursorAndWipeEntireRow(0, 3);
        Console.ForegroundColor = attacker.Color;
        TextEffects.PrintTextCharByChar($"{attacker.Name} rolls their {attacker.AttackDice.ToString()} and strikes {defender.Name} dealing {damage} damage.");
        Console.ResetColor();

        defender.TakeDamage(damage);

        Thread.Sleep(1300);
        TextEffects.SetCursorAndWipeEntireRow(0, 3);
        TextEffects.SetCursorAndWipeEntireRow(0, 4); //TODO: den här raden tar bort deathmessage (från Rat/Snake) vid rätt tidpunkt - vilket inte är så snyggt, men har ingen bättre lösning just nu.

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