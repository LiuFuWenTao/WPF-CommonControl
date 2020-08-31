using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfCommondControlApp.Convert
{
    /// <summary>
    /// 描述：
    /// 作者：liufuwentao
    /// 时间：2020/8/31 13:18:14
    /// </summary>
    public class StringToCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCheck;
            if (!bool.TryParse(value?.ToString(), out isCheck) || parameter == null) return "";
            return isCheck ? parameter.ToString().ToUpperInvariant() : parameter.ToString().ToLowerInvariant();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
