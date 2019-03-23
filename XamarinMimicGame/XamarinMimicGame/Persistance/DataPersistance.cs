using XamarinMimicGame.Model;

namespace XamarinMimicGame.Persistance
{
    public class DataPersistance
    {
        public static Game Game { get; set; }
        public static short CurrentRound { get; set; }
        public static string[][] Words = {
            //easy. Score 1
            new [] { "eye", "tongue", "sleeper", "corn", "goal", "ball", "soccer" },

            //normal Score 3
            new [] { "wordcraft", "yellow", "lemon", "bee" },

            //difficult Score 5
            new [] { "flashlight", "movie", "batman", "notebook" },
        };
    }
}
