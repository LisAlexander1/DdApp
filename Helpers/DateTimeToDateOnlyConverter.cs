using System.Globalization;
using System.Windows.Data;

namespace DdApp.Helpers;

public class DateOnlyToDateTimeConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? default(object) : ((DateOnly)value).ToDateTime(new TimeOnly(0, 0));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DateOnly.FromDateTime((DateTime)value);

    }
}