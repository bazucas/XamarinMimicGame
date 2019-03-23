using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinMimicGame.Annotations;
using XamarinMimicGame.Model;
using XamarinMimicGame.Persistance;

namespace XamarinMimicGame.ViewModel
{
    public class SplashScreenViewModel : INotifyPropertyChanged
    {
        private string _errorMsg;

        public SplashScreenViewModel()
        {
            BeginCommand = new Command(StartGame);
            Game = new Game {GroupOne = new Group(), GroupTwo = new Group(), WordTime = 60, Rounds = 3};
        }

        public Game Game { get; set; }
        public Command BeginCommand { get; set; }

        public string ErrorMsg
        {
            get => _errorMsg;
            set
            {
                _errorMsg = value;
                OnPropertyChanged(nameof(ErrorMsg));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void StartGame()
        {
            var error = "";
            if (Game.WordTime < 10) error += "The minimum time for each word is 10 seconds.";
            if (Game.Rounds <= 0) error += "\nThe round minimum value is 1.";

            if (error.Length > 0)
            {
                ErrorMsg = error;
            }

            else
            {
                DataPersistance.Game = Game;
                DataPersistance.CurrentRound = 1;

                Application.Current.MainPage = new View.Game(Game.GroupOne);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}