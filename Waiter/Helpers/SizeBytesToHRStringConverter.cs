using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Waiter.Helpers
{
    // HR = Human-Readable
    internal class SizeBytesToHRStringConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // https://stackoverflow.com/a/4975942
            string[] suf = { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" }; //Longs run out around EB
            if ((long)value == 0)
                return "0" + suf[0];
            long bytes = Math.Abs((long)value);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 2);
            return (Math.Sign((long)value) * num).ToString() + " " + suf[place];
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
