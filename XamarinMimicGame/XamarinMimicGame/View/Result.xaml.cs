﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMimicGame.ViewModel;

namespace XamarinMimicGame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        public Result()
        {
            InitializeComponent();

            BindingContext = new ResultViewModel();
        }
    }
}