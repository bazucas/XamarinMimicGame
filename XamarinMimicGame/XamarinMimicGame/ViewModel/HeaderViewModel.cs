using Xamarin.Forms;
using XamarinMimicGame.View;

namespace XamarinMimicGame.ViewModel
{
    public class HeaderViewModel
    {
        public HeaderViewModel()
        {
            Leave = new Command(LeaveAction);
        }

        public Command Leave { get; set; }

        private static void LeaveAction()
        {
            Application.Current.MainPage = new StartGame();
        }
    }
}