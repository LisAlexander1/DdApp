using System.Collections.ObjectModel;

namespace DdApp.Extensions;

public static class IEnumerable
{
    public static ObservableCollection<T> ToObservableCollection<T>
        (this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return new ObservableCollection<T>(source);
    }
}