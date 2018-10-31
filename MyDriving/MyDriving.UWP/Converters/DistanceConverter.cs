using System;
using Windows.UI.Xaml.Data;
using MyDriving.Utils;

namespace MyDriving.UWP.Converters
{
    // TODO: Corregir 1 dato (Settings)
    //convert miles to km. Input is miles
    public class DistanceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "0 miles";

            double distance = (double) value;
/* 1            if (Settings.Current.MetricDistance)
            {
                double km = distance*1.60934;
                return string.Format("{0:0.00} km", km);
            }
            else */
                return string.Format("{0:0.00} miles", distance);
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}