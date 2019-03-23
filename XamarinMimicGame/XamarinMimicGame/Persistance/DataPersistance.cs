using XamarinMimicGame.Model;

namespace XamarinMimicGame.Persistance
{
    public class DataPersistance
    {
        public static string[][] Words =
        {
            //easy Score 1
            new[] {"easy1", "easy2", "easy3", "easy4"},

            //normal Score 3
            new[] {"normal1", "normal2", "normal3", "normal4"},

            //difficult Score 5
            new[] {"hard1", "hard2", "hard3", "hard4"}
        };

        public static Game Game { get; set; }
        public static short CurrentRound { get; set; }
    }
}