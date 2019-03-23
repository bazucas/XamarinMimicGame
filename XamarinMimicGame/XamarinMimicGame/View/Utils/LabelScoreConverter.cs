using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinMimicGame.View.Utils
{
    public class LabelScoreConverter : IValueConverter
    {
        //View > ViewModel(Data)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((byte) value == 0)
                return "Word";
            return "Word - Score: " + value;
        }

        //ViewModel > View
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}