using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Waiter.Helpers
{
    // https://stackoverflow.com/questions/4253554/xaml-binding-to-a-converter
    internal class MultiplyByFactorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse(parameter.ToString(), out var factor);
            return factor * (double)value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
