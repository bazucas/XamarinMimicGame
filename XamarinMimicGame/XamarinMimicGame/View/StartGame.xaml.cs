using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGame : ContentPage
    {
        public StartGame()
        {
            InitializeComponent();

            BindingContext = new SplashScreenViewModel();
        }
    }
}