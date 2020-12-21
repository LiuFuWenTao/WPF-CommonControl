using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCommondControlApp.Control
{
    /// <summary>
    /// 描述：小数输入框控件，只允许输入小数
    /// //xmlns:input="clr-namespace:System.Windows.Input;assembly=PresentationCore"
    //<uc:DoubleTextBox Width="100" Background="Black" Height="50" input:InputMethod.IsInputMethodEnabled="False"></uc:DoubleTextBox>
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class DoubleTextBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleTextBox"/> class.
        /// </summary>
        public DoubleTextBox()
            : base()
        {
            this.Style = this.FindResource("textBox") as Style;
            this.PreviewTextInput += this.DoubleTextBox_PreviewTextInput;
            this.TextChanged += this.IntegerTextBox_TextChanged;
        }

        private void IntegerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double v = 0;
            if (!double.TryParse(this.Text, out v))
            {
                TextChange change = e.Changes.ElementAt(0);
                if (change.AddedLength > 0)
                {
                    this.Text = this.Text.Remove(change.Offset, change.AddedLength);
                    this.Select(change.Offset, 0);
                }
            }
        }

        private void DoubleTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            for (int i = 0; i < e.Text.Length; i++)
            {
                // 如果输入不合法，就不允许输入
                if (!(char.IsNumber(e.Text.ElementAt(i)) || e.Text.ElementAt(i).Equals('.')))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}