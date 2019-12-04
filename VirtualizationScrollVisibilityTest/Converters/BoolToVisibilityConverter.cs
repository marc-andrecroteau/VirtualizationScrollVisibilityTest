using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VirtualizationScrollVisibilityTest.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {

        public bool InvertVisibility { get; set; }


        public object Convert(object value, Type targetType, object hideParameter, CultureInfo culture)
        {
            var flag = false;

            if (value is bool)
            {
                flag = (bool)value;
                if (InvertVisibility)
                    flag = !flag;
            }

            if (flag) return Visibility.Visible;
            
            if (hideParameter == null) return Visibility.Collapsed;

            return bool.Parse((string)hideParameter) ? Visibility.Hidden : Visibility.Collapsed;
        }


        public object ConvertBack(object value, Type targetType, object hideParameter, CultureInfo culture)
        {
            var back = value is Visibility && ((Visibility)value == Visibility.Visible);

            if (InvertVisibility)
                back = !back;

            return back;
        }
    }
}