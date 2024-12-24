using System;
using System.Text;

namespace DroidBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Ласкаво просимо до Битви Дроїдів!");
            Console.WriteLine("Виберіть режим гри:");
            Console.WriteLine("1. Гравець проти дроїда.");
            Console.WriteLine("2. Бій 2 на 2.");
            Console.WriteLine("3. Гравець проти гравця.");
            Console.WriteLine("4. RPG режим.");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Droid player = CreateDroid("Ваш дроїд");
                    Droid bot = CreateDroid("Дроїд-суперник");
                    BattleModes.StartDuel(player, bot);
                    break;

                case 2:
                    Droid[] team1 = { CreateDroid("Дроїд 1 команди 1"), CreateDroid("Дроїд 2 команди 1") };
                    Droid[] team2 = { CreateDroid("Дроїд 1 команди 2"), CreateDroid("Дроїд 2 команди 2") };
                    BattleModes.StartTeamBattle(team1, team2);
                    break;

                case 3:
                    Droid player1 = CreateDroid("Гравець 1");
                    Droid player2 = CreateDroid("Гравець 2");
                    BattleModes.StartPlayerVsPlayer(player1, player2);
                    break;

                case 4:
                    RPGMode rpg = new RPGMode();
                    rpg.StartRPG();
                    break;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }

            Console.WriteLine("Гра завершена!");
        }

        static Droid CreateDroid(string name)
        {
            Console.WriteLine($"Виберіть тип для {name}:");
            Console.WriteLine("1. Атакуючий дроїд (Здоров'я: 90, Атака: 30).");
            Console.WriteLine("2. Оборонний дроїд (Здоров'я: 150, Атака: 20).");
            int type = int.Parse(Console.ReadLine());

            return type == 1 ? new AttackDroid(name) : new DefenseDroid(name);
        }
    }
}
