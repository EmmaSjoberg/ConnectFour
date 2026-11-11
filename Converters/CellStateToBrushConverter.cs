using ConnectFour.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
namespace ConnectFour.Converters;
public sealed class CellStateToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string key = value is CellState state ? state switch { CellState.PlayerOne => "PlayerOneBrush", CellState.PlayerTwo => "PlayerTwoBrush", _ => "EmptyCellBrush" } : "EmptyCellBrush";
        return Application.Current.TryFindResource(key) as Brush ?? Brushes.Transparent;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
}
