using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCommondControlApp.Control
{
    /// <summary>
    /// AnimationEnterAndLeave.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationEnterAndLeave : UserControl
    {
        public AnimationEnterAndLeave()
        {
            InitializeComponent();
        }
        #region 开始和结束得动画
        private void stackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this.aboutPop.IsMouseOver)
            {
                Console.WriteLine("开始动画");
                DoubleAnimation doubleanimation = new DoubleAnimation();
                doubleanimation.From = 0;
                doubleanimation.To = stackPanel.ActualHeight;
                doubleanimation.Duration = TimeSpan.FromSeconds(1);
                doubleanimation.FillBehavior = FillBehavior.HoldEnd;
                ss.BeginAnimation(TranslateTransform.YProperty, doubleanimation);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void stackPanel1_MouseEnter(object sender, MouseEventArgs e)
        {
            ss.Y = stackPanel.ActualHeight;
            aboutPop.IsOpen = true;
            Console.WriteLine("开始进入动画");
            DoubleAnimation doubleanimation = new DoubleAnimation();
            doubleanimation.From = stackPanel.ActualHeight;
            doubleanimation.To = 0;
            doubleanimation.Duration = TimeSpan.FromSeconds(1);
            doubleanimation.FillBehavior = FillBehavior.HoldEnd;
            ss.BeginAnimation(TranslateTransform.YProperty, doubleanimation);

        }
        #endregion
    }
}
