using System;

namespace DroidBattle
{
    abstract class Droid
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Droid(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public virtual void Attack(Droid target)
        {
            Random random = new Random();
            int roll = random.Next(0, 10); // Рандомне число від 0 до 9

            int damage = AttackPower;

            if (roll == 0)
            {
                damage *= 2; // Критичний удар
                Console.WriteLine($"{Name} завдає критичний удар!");
            }
            else if (roll == 1 || roll == 2)
            {
                damage /= 2; // Невдалий удар
                Console.WriteLine($"{Name} завдає невдалий удар.");
            }
            else
            {
                Console.WriteLine($"{Name} завдає звичайний удар.");
            }

            Console.WriteLine($"{Name} атакує {target.Name}, завдаючи {damage} шкоди.");
            target.Defend(damage);
        }

        public virtual void Defend(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} отримує {damage} шкоди. Здоров'я: {Health}");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    class AttackDroid : Droid
    {
        public AttackDroid(string name) : base(name, 90, 30) { }
    }

    class DefenseDroid : Droid
    {
        public DefenseDroid(string name) : base(name, 150, 20) { }

        public override void Defend(int damage)
        {
            int reducedDamage = damage / 2;
            Console.WriteLine($"{Name} зменшує шкоду до {reducedDamage}!");
            base.Defend(reducedDamage);
        }
    }
}
