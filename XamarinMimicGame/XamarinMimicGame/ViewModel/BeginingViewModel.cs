using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinMimicGame.Annotations;
using XamarinMimicGame.Model;
using XamarinMimicGame.Persistance;

namespace XamarinMimicGame.ViewModel
{
    public class BeginingViewModel: INotifyPropertyChanged
    {
        public Game Game { get; set; }
        public Command BeginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BeginingViewModel()
        {
            BeginCommand = new Command(BeginGame);
            Game = new Game {GroupOne = new Group(), GroupTwo = new Group()};
        }

        private void BeginGame()
        {
            DataPersistance.Game = Game;
            DataPersistance.CurrentRound = 1;
            Application.Current.MainPage = new View.Game();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
