using System;
using System.Globalization;
using System.Windows.Data;

namespace VirtualizationScrollVisibilityTest.Converters
{
    public class BoolToMarginVisibilityConverter : IValueConverter
    {

        public bool InvertVisibility { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;

            if (value is bool)
            {
                flag = (bool)value;
                if (InvertVisibility)
                    flag = !flag;
            }

            return flag ? parameter : 0;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}