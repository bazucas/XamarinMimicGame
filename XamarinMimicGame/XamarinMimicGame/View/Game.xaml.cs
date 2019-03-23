using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        public Game()
        {
            InitializeComponent();

            BindingContext = new GameViewModel();
        }
    }
}