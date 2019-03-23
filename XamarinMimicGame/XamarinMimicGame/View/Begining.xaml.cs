using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.Annotations;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Begining : ContentPage
    {
        public Begining()
        {
            InitializeComponent();

            BindingContext = new BeginingViewModel();
        }

        //public class Groups : INotifyPropertyChanged
        //{
        //    private string _groupNameOne;

        //    public string GroupNameOne
        //    {
        //        get => _groupNameOne;
        //        set
        //        {
        //            _groupNameOne = value;
        //            PropertyChangedEvent("GroupNameOne");
        //        }
        //    }

        //    public Groups()
        //    {
        //        GroupNameOne = "Men";
        //    }

        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private void PropertyChangedEvent(string property)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        //    }
        //}
    }
}