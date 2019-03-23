using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.Model;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        public Game(Group group)
        {
            InitializeComponent();

            BindingContext = new GameViewModel(group);
        }
    }
}