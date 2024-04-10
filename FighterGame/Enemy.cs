using FighterGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterGame
{

    public class Enemy
    {
        public int Health { get; private set; }

        public Enemy(int health)
        {
            Health = health;
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
            int damage = rand.Next(5, 16);
            player.ReceiveDamage(damage);
            return damage;
        }
    }

}