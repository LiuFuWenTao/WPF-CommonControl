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
    /// 时间：2020/8/31 13:18:49
    public class SymbolToMoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCheck;
            if (!bool.TryParse(value?.ToString(), out isCheck) || parameter == null) return "";
            var temp = string.Empty;
            temp = parameter.ToString();
            if (!isCheck)
            {
                switch (parameter.ToString())
                {
                    case "_":
                        temp = "`";
                        break;
                    case "-":
                        temp = "~";
                        break;
                    case "+":
                        temp = "!";
                        break;
                    case "=":
                        temp = "@";
                        break;
                    case "<":
                        temp = "#";
                        break;
                    case ">":
                        temp = "$";
                        break;
                    case "|":
                        temp = "%";
                        break;

                    default:
                        temp = parameter.ToString();
                        break;

                }
            }

            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
