using FighterGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterGame
{
    public class Level
    {
        private Player player;
        private Enemy[] enemies;
        private int levelNumber;
        private BossEnemy boss;

        public Level(Player player, int levelNumber, int numberOfEnemies)
        {
            this.player = player;
            this.levelNumber = levelNumber;
            enemies = new Enemy[numberOfEnemies];
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies[i] = new Enemy(50);
            }
            boss = new BossEnemy(150);
        }

        public void Play()

        {

            Console.Clear();
            if (levelNumber == 1)
            {
                Console.WriteLine($"Floor : {levelNumber}");
                Console.WriteLine($"Enemies Found : {levelNumber}");
            }
            player.Reset();
            UnlockItems();

            while (player.Health > 0 && AnyEnemyAlive())
            {
                Console.WriteLine("Choose Action");
                Console.WriteLine("A. Attack");
                Console.WriteLine("H. Heal");

                char action = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (levelNumber == 6)
                {
                    switch (action)
                    {

                        case 'A':
                        case 'a':

                            int enemyDamage = 0;

                            int playerDamageFromBoss = player.AttackBoss(boss);
                            if (boss.Health > 0)
                            {
                                enemyDamage = boss.Attack(player);
                                Console.WriteLine($"Boss Attacked: {enemyDamage}");


                                Console.WriteLine($"Player Health: {player.Health}");
                                Console.WriteLine($"Player Attacked: {playerDamageFromBoss}");
                                Console.WriteLine($"Boss Health: {boss.Health}");
                            }
                            else
                            {
                                Console.WriteLine($"Boss Attacked: {enemyDamage}");


                                Console.WriteLine($"Player Health: {player.Health}");
                                Console.WriteLine($"Player Attacked: {playerDamageFromBoss}");
                                Console.WriteLine($"Boss Health: {boss.Health}");
                                Console.WriteLine("Congratulations! You have defeated Murlocs. The village is safe now!");
                                break;
                            }
                            break;
                        case 'H':
                        case 'h':
                            player.HealPlayer();
                            break;

                        default:
                            Console.WriteLine("Invalid action! Please choose A for Attack or H for Heal.");
                            continue;

                    }
                }
                else
                {
                    switch (action)
                    {

                        case 'A':
                        case 'a':


                            int playerDamage = player.Attack(enemies);


                            for (int i = 0; i < enemies.Length; i++)
                            {
                                if (enemies[i].Health > 0)
                                {
                                    int enemyDamage = enemies[i].Attack(player);
                                    Console.WriteLine($"Enemy {i + 1} Attacked: {enemyDamage}");
                                }
                            }
                            Console.WriteLine($"Player Health: {player.Health}");
                            Console.WriteLine($"Player Attacked: {playerDamage}");
                            for (int i = 0; i < enemies.Length; i++)
                            {
                                Console.WriteLine($"Enemy{i + 1} Health: {enemies[i].Health}");
                            }

                            break;

                        case 'H':
                        case 'h':
                            player.HealPlayer();
                            break;

                        default:
                            Console.WriteLine("Invalid action! Please choose A for Attack or H for Heal.");
                            continue;
                    }
                }
            }
            if (player.Health <= 0)
            {
                Console.WriteLine("Game Over. The village has fallen to Murlocs.");
            }
        }



        private bool AnyEnemyAlive()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Health > 0)
                    return true;
            }
            return false;
        }

        private void UnlockItems()
        {
            switch (levelNumber)
            {

                case 2:
                    Console.WriteLine($"Level Complete!");

                    Console.WriteLine("Player Got a map! ");
                    player.EquipSword();
                    player.SetAbility(SpecialAbility.CriticalHit);
                    Console.WriteLine("Player equipped with Sword and unlocked Critical Hit ability!");
                    Console.WriteLine($"Floor Reached :{levelNumber}");
                    Console.WriteLine($"Enemies Found :{levelNumber}");
                    break;
                case 3:
                    Console.WriteLine($"Level Complete!");
                    player.EquipShield();
                    player.SetAbility(SpecialAbility.Blocker);
                    Console.WriteLine("Player equipped with Shield and unlocked Blocker ability!"); Console.WriteLine($"Floor Reached :{levelNumber}");
                    Console.WriteLine($"Enemies Found :{levelNumber}");
                    break;
                case 4:
                    Console.WriteLine($"Level Complete!");
                    player.EquipArmor();
                    player.SetAbility(SpecialAbility.LifeSteal);
                    Console.WriteLine("Player equipped with Armor and unlocked Life Steal ability!");
                    Console.WriteLine($"Floor Reached :{levelNumber}");
                    Console.WriteLine($"Enemies Found :{levelNumber}");
                    break;
                case 5:
                    Console.WriteLine($"Level Complete!");
                    player.EquipBow();
                    player.SetAbility(SpecialAbility.RangedAttack);
                    Console.WriteLine("Player equipped with Bow and unlocked Ranged Attack ability!");
                    Console.WriteLine($"Floor Reached :{levelNumber}");
                    Console.WriteLine($"Enemies Found :{levelNumber}");
                    break;
                case 6:
                    Console.WriteLine("Level Complete!");
                    Console.WriteLine("Fight Against Boss Begins!");
                    break;

            }
        }
    }
}