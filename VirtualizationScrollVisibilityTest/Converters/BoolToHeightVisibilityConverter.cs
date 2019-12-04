using System;
using System.Globalization;
using System.Windows.Data;

namespace VirtualizationScrollVisibilityTest.Converters
{
    public class BoolToHeightVisibilityConverter : IValueConverter
    {
        
        // Voir : https://stackoverflow.com/questions/9191701/virtualizingstackpanel-not-handling-collapsed-items-correctly
        // Ou bien : https://social.msdn.microsoft.com/Forums/en-US/5930244b-f4ef-492f-b4e8-49ddb3f2863d/virtualizingstackpanel-not-handling-collapsed-items-correctly

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

            return flag ? 17.96 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}