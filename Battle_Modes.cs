using System;

namespace DroidBattle
{
    class BattleModes
    {
        public static void StartDuel(Droid droid1, Droid droid2)
        {
            Console.WriteLine($"Бій починається між {droid1.Name} та {droid2.Name}!");

            while (droid1.IsAlive() && droid2.IsAlive())
            {
                droid1.Attack(droid2);
                if (droid2.IsAlive())
                    droid2.Attack(droid1);
            }

            Console.WriteLine(droid1.IsAlive() ? $"{droid1.Name} переміг!" : $"{droid2.Name} переміг!");
        }

        public static void StartPlayerVsPlayer(Droid player1, Droid player2)
        {
            Console.WriteLine($"Бій починається між гравцями: {player1.Name} та {player2.Name}!");

            while (player1.IsAlive() && player2.IsAlive())
            {
                player1.Attack(player2);
                if (player2.IsAlive())
                    player2.Attack(player1);
            }

            Console.WriteLine(player1.IsAlive() ? $"{player1.Name} переміг!" : $"{player2.Name} переміг!");
        }

        public static void StartTeamBattle(Droid[] team1, Droid[] team2)
        {
            Console.WriteLine("Починається битва 2 на 2!");

            int t1Index = 0, t2Index = 0;

            while (t1Index < team1.Length && t2Index < team2.Length)
            {
                team1[t1Index].Attack(team2[t2Index]);
                if (!team2[t2Index].IsAlive())
                {
                    Console.WriteLine($"{team2[t2Index].Name} вибув!");
                    t2Index++;
                }

                if (t2Index < team2.Length)
                {
                    team2[t2Index].Attack(team1[t1Index]);
                    if (!team1[t1Index].IsAlive())
                    {
                        Console.WriteLine($"{team1[t1Index].Name} вибув!");
                        t1Index++;
                    }
                }
            }

            Console.WriteLine(t1Index < team1.Length ? "Команда 1 перемогла!" : "Команда 2 перемогла!");
        }
    }
}
