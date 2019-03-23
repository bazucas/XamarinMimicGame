using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinMimicGame.Annotations;
using XamarinMimicGame.Persistance;
using XamarinMimicGame.View;
using Game = XamarinMimicGame.Model.Game;

namespace XamarinMimicGame.ViewModel
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        public ResultViewModel()
        {
            Game = DataPersistance.Game;
            PlayAgain = new Command(PlayAgainAction);
        }

        public Game Game { get; set; }
        public Command PlayAgain { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private static void PlayAgainAction()
        {
            Application.Current.MainPage = new StartGame();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}