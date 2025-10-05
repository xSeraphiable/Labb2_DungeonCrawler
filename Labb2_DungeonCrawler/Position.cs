using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler
{
    class Position
    {
        public static void IsEnemyInsideLevel(Enemy enemy, IReadOnlyList<LevelElement> Elements, int oldx, int oldy)
        {
            ///TODO: måste även kolla koordinater mot spelaren.
            foreach (var element in Elements)
            {
                
                if (enemy.x == element.x && enemy.y == element.y)
                {
                    enemy.x = oldx;
                    enemy.y = oldy;
                    break;

                    
                }
            }
        }

        public static void IsPlayerInsideLevel(Player p, IReadOnlyList<LevelElement> Elements, int oldx, int oldy)
        {
            foreach (var element in Elements)
            {
                if (element.x == p.x && element.y == p.y)
                {
                    if (element.displayChar == '#')
                    {
                        p.x = oldx;
                        p.y = oldy;
                        break;
                    }

                    else if (element.displayChar == 'r')
                    {
                        p.x = oldx;
                        p.y = oldy;
                        //start attack
                    }

                    else if (element.displayChar == 's')
                    {
                        p.x = oldx;
                        p.y = oldy;
                        //start attack
                    }


                }
            }
        }


    }
}
