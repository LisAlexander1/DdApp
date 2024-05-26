using System.Globalization;
using System.Windows.Data;

namespace DdApp.Helpers;

public class LongToDoubleConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return System.Convert.ToDouble(value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == "" ? null : System.Convert.ToInt64(value);
    }
}