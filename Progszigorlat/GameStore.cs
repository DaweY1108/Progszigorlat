using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Progszigorlat
{
    public class GameStore
    {
        public List<Game> games;
        
        //2. Feladat
        public GameStore(string path)
        {
            games = new List<Game>();

            try
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(';');
                    string Platform = data[0];
                    bool Played = data[1].Equals("X");
                    string Name = data[2];
                    int OpenCritic;
                    try
                    {
                        OpenCritic = Convert.ToInt32(data[3]);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Error while converting integer");
                        OpenCritic = 0;
                    }

                    string Genre = data[4];
                    string Multiplayer = data[5];
                    string Source = data[6];
                    Game game = new Game(Platform, Played, Name, OpenCritic, Genre, Multiplayer, Source);
                    games.Add(game);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while reading file: " + path);
            }
        }

        //3. Feladat
        public void ShowData()
        {
            Console.WriteLine("3. Feladat:\n");
            Console.WriteLine($"{"Platform", -10} {"Played", -10} {"OpenCritic", -15} {"Multiplayer", -15} {"Name"}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(games[i]);
            }
            Console.WriteLine();
        }
        
        //4. Feladat
        public void PS45Games()
        {
            List<Game> playableGames = new List<Game>();
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Platform.Equals("PS4/PS5") && games[i].OpenCritic >= 90) playableGames.Add(games[i]);
            }

            Console.WriteLine("4. Feladat\n");
            for (int i = 0; i < playableGames.Count; i++)
            {
                Console.WriteLine(playableGames[i]);
            }
            Console.WriteLine($"\nPS4-re és PS5-re összesen {playableGames.Count}db játék érhető el ami legalább 90%-os értékelést kapott");
            for (int i = 0; i < playableGames.Count; i++)
            {
                Console.WriteLine(playableGames[i].Name);
            }
            Console.WriteLine();
        }
        
        //5. Feladat
        public void GroupRatings()
        {
            Console.WriteLine("5. Feladat:\n");
            Console.WriteLine("Játékértékelések:");
            int best = 0;
            int good = 0;
            int playable = 0;
            int bad = 0;

            for (int i = 0; i < games.Count; i++)
            {
                int rating = games[i].OpenCritic;
                if (rating >= 0 && rating <= 70) bad++;
                if (rating >= 71 && rating <= 80) playable++;
                if (rating >= 81 && rating <= 90) good++;
                if (rating >= 91 && rating <= 100) best++;
            }

            Console.WriteLine($"Kiváló (91-100): {best}db");
            Console.WriteLine($"Jó (81-90): {good}db");
            Console.WriteLine($"Játszható (71-80): {playable}db");
            Console.WriteLine($"Rossz (0-70): {bad}db");
            Console.WriteLine();
            
        }

        //6. Feladat
        public bool Search(string name)
        {
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Name.Equals(name)) return true;
            }
            return false;
        }

        //7. Feladat
        public void BestGame()
        {
            Console.WriteLine("7. Feladat:\n");
            int bestGameID = 0, bestGameRating = 0;
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].OpenCritic > bestGameRating)
                {
                    bestGameRating = games[i].OpenCritic;
                    bestGameID = i;
                }
            }
            Console.WriteLine($"A legjobbra értékelt játék: {games[bestGameID].Name} ({games[bestGameID].OpenCritic})\n");
        }

        //8. Feladat
        public void Multiplayer()
        {
            int online = 0;
            int local = 0;
            int both = 0;

            Console.WriteLine("8. Feladat:\n");
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Multiplayer.Equals("Online")) online++;
                if (games[i].Multiplayer.Equals("Local")) local++;
                if (games[i].Multiplayer.Equals("Both")) both++;
            }

            Console.WriteLine("Multiplayer játszhatóság:");
            Console.WriteLine($"Online: {online}");
            Console.WriteLine($"Local: {local}");
            Console.WriteLine($"Both: {both}");
        }
    }
}