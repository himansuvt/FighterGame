using System.Numerics;
using System.Reflection.Emit;

namespace FighterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(150);
            int level = 1;
            int numberOfEnemies = 1;

            BossEnemy boss = new BossEnemy(50);
            while (level <= 6 && player.Health > 0)
            {
                Level currentLevel = new Level(player, level, numberOfEnemies);
                currentLevel.Play();



                level++;
                if (level <= 5)
                {
                    numberOfEnemies++;
                }
            }


        }
    }
}
