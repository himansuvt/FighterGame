using FighterGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FighterGame
{

    public enum SpecialAbility
    {
        None,
        CriticalHit,
        Blocker,
        LifeSteal,
        RangedAttack
    }

    public class Player
    {
        public int Health { get; private set; }
        public bool Sword { get; private set; }
        public bool Shield { get; private set; }
        public bool Armor { get; private set; }
        public bool Bow { get; private set; }
        public SpecialAbility Ability { get; private set; }

        private int healCount = 0;

        public Player(int startingHealth)
        {
            Health = startingHealth;
            Sword = false;
            Shield = false;
            Armor = false;
            Bow = false;
            Ability = SpecialAbility.None;
        }
        public void ReceiveDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
        public int Attack(Enemy[] enemies)
        {
            Random rand = new Random();
            int totalDamage = 0;

            foreach (Enemy enemy in enemies)
            {
                if (enemy.Health > 0)
                {
                    int damage = rand.Next(10, 21);
                    enemy.ReceiveDamage(damage);
                    totalDamage += damage;
                }
            }

            return totalDamage;
        }




        public void HealPlayer()
        {
            if (healCount < 3)
            {
                Health += 20;
                if (Health > 150)
                    Health = 150;

                healCount++;
                Console.WriteLine("Player healed! Health increased by 20.");
            }
            else
            {
                Console.WriteLine("You've reached the maximum number of heals!");
            }
        }

        public void EquipSword()
        {
            Sword = true;
        }

        public void EquipShield()
        {
            Shield = true;
        }

        public void EquipArmor()
        {
            Armor = true;
        }

        public void EquipBow()
        {
            Bow = true;
        }

        public void SetAbility(SpecialAbility ability)
        {
            Ability = ability;
        }

        public void Reset()
        {
            Health = 150;
            Ability = SpecialAbility.None;
            healCount = 0;
        }

        internal int AttackBoss(BossEnemy boss)
        {
            Random rand = new Random();

            int damage = 0;

            if (boss.Health > 0)
            {
                damage = rand.Next(10, 26);
                boss.ReceiveDamage(damage);

            }


            return damage;
        }
    }



}