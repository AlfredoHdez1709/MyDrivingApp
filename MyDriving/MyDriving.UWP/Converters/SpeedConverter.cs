using System;
using Windows.UI.Xaml.Data;
using MyDriving.Utils;

namespace MyDriving.UWP.Converters
{
    public class SpeedConverter : IValueConverter
    {
        //TODO: Fix 1
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "0 miles";

            double mph = (double) value;
/*1            if (Settings.Current.MetricDistance)
            {
                double kmh = mph*1.60934;
                return string.Format("{0} km/h", (int) kmh);
            }
            else
*/                return string.Format("{0} mph", (int) mph);
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}