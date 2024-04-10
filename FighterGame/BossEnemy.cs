using FighterGame;
using System;

namespace FighterGame
{
    public class BossEnemy
    {
        public int Health { get; set; }

        public BossEnemy(int health)
        {
            Health = health;

        }
        public int getHealth(int health)
        {
            return health;
        }
        public void ReceiveDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public int Attack(Player player)
        {
            Random rand = new Random();
            int damage = rand.Next(10, 26); // Boss deals higher damage
            player.ReceiveDamage(damage);
            return damage;
        }
    }
}
