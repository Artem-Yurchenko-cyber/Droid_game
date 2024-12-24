using System;
using System.Text;

namespace DroidBattle
{
    class RPGMode
    {
        class PlayerDroid : Droid
        {
            public PlayerDroid(string name) : base(name, 150, 30) { }

            public override void Attack(Droid target)
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
        }

        class EnemyDroid : Droid
        {
            public EnemyDroid(string name, int attackPower) : base(name, 30, attackPower) { }

            public override void Attack(Droid target)
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
        }

        public void StartRPG()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ласкаво просимо до RPG режиму Битва Дроїдів!");

            PlayerDroid player = new PlayerDroid("Ваш дроїд");
            int wave = 1;
            int mana = 0;
            int energy = 0;

            while (player.IsAlive())
            {
                Console.WriteLine($"\nХвиля {wave}!");
                EnemyDroid enemy = new EnemyDroid($"Суперник {wave}", 30 + (wave - 1) * 2);

                while (enemy.IsAlive() && player.IsAlive())
                {
                    Console.WriteLine("Ваш хід! Натисніть [A] для атаки, [S] для спеціальної атаки, [M] для використання мани.");
                    var input = Console.ReadKey(true).Key;

                    if (input == ConsoleKey.A)
                    {
                        player.Attack(enemy);
                        mana++;
                    }
                    else if (input == ConsoleKey.S)
                    {
                        if (energy >= 5)
                        {
                            Console.WriteLine("Використовується потужна атака!");
                            enemy.Health = 0;
                            energy = 0;
                        }
                        else
                        {
                            Console.WriteLine("Енергія неповна. Потужна атака недоступна!");
                        }
                    }
                    else if (input == ConsoleKey.M)
                    {
                        if (mana >= 10)
                        {
                            Console.WriteLine("Використовується мана! Відновлюється 10 здоров'я.");
                            player.Health += 10;
                            mana -= 10;
                        }
                        else
                        {
                            Console.WriteLine("Недостатньо мани для використання.");
                        }
                    }

                    if (enemy.IsAlive())
                    {
                        enemy.Attack(player);
                    }
                }

                if (player.IsAlive())
                {
                    Console.WriteLine($"Хвиля {wave} завершена! {player.Name} має {player.Health} здоров'я.");
                    player.Health = Math.Min(player.Health + 10, 150); // Відновлюється, але не більше за 150
                    wave++;
                    energy++;
                }
            }

            Console.WriteLine("Гру завершено! Ваш дроїд знищено.");
        }
    }
}
