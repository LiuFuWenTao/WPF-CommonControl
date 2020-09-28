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
    /// 描述：用法
    /// xmlns:input="clr-namespace:System.Windows.Input;assembly=PresentationCore"
    /*<uc1:CommonTextBox Style="{StaticResource textBox}" input:InputMethod.IsInputMethodEnabled="False" Height="50" Width="100" Background="Black"></uc1:CommonTextBox>*/
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class CommonTextBox : TextBox
    {
        public CommonTextBox()
            : base()
        {
            this.Style = this.FindResource("textBox") as Style;
            this.PreviewTextInput += this.IntegerTextBox_PreviewTextInput;
            this.TextChanged += this.IntegerTextBox_TextChanged;
        }

        private void IntegerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                long v = 0;
                if (!long.TryParse(this.Text, out v))
                {
                    TextChange change = e.Changes.ElementAt(0);
                    if (change.AddedLength > 0)
                    {
                        this.Text = this.Text.Remove(change.Offset, change.AddedLength);
                        this.Select(change.Offset, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void IntegerTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            for (int i = 0; i < e.Text.Length; i++)
            {
                if (!char.IsNumber(e.Text.ElementAt(i)))
                {
                    Console.WriteLine("不允许输入" + e.Text.ElementAt(i));
                    e.Handled = true;
                    return;
                }
                Console.WriteLine("允许输入" + e.Text.ElementAt(i));
            }
        }
    }
}
