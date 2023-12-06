namespace Progszigorlat
{
    public class Game
    {
        public string Platform;
        public bool Played;
        public string Name;
        public int OpenCritic;
        public string Genre;
        public string Multiplayer;
        public string Source;
        
        public Game(string platform, bool played, string name, int openCritic, string genre, string multiplayer, string source)
        {
            Platform = platform;
            Played = played;
            Name = name;
            OpenCritic = openCritic;
            Genre = genre;
            Multiplayer = multiplayer;
            Source = source;
        }

        public override string ToString()
        {
            return $"{Platform, -10} {(Played ? "X" : " "), -10} {OpenCritic, -15} {Multiplayer, -15} {Name}";
        }
    }
}