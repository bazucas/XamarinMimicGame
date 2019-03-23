using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Header : ContentView
    {
        public Header()
        {
            InitializeComponent();
            BindingContext = new HeaderViewModel();
        }

        private void LeaveEvent(object sender, EventArgs e)
        {
            var viewModel = (HeaderViewModel) BindingContext;

            if (viewModel.Leave.CanExecute(null)) viewModel.Leave.Execute(null);
        }
    }
}