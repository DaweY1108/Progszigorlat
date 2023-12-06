using System;

namespace Progszigorlat
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameStore gameStore = new GameStore("C:/Users/DaweY/Desktop/ps_extra_games_input.csv");
            gameStore.ShowData();
            gameStore.PS45Games();
            gameStore.GroupRatings();
            Console.WriteLine("6. Feladat:\n");
            Console.WriteLine("Adja meg a keresett játék nevét:");
            if (gameStore.Search(Console.ReadLine()))
            {
                Console.WriteLine("A keresett játék létezik az adatbázisban!\n");
            }
            else
            {
                Console.WriteLine("A keresett játék NEM létezik az adatbázisban!\n");
            }
            gameStore.BestGame();
            gameStore.Multiplayer();
            Console.WriteLine("Done.");
        }
    }
}