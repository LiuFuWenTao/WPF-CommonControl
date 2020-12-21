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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCommondControlApp.创意控件
{
    /// <summary>
    /// DescribeUserControl.xaml 的交互逻辑
    /*   <cykj1:DescribeUserControl  Height="200" Width="400" Background="Transparent" Describe="车身的高度" DescribeValue="100"
                                  X1="150" Y1="59" X2="155" Y2="69" X3="50" Y3="90" X4="50" Y4="120" Margin="23,34,0,0" ColorOverlay="#FF213D44"
                                  HorizontalAlignment="Left" VerticalAlignment="Top"></cykj1:DescribeUserControl> */
    /// </summary>
    public partial class DescribeUserControl : UserControl
    {
        #region 依赖属性
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe
        {
            get { return (string)GetValue(DescribeProperty); }
            set { SetValue(DescribeProperty, value); }
        }

        public static readonly DependencyProperty DescribeProperty =
            DependencyProperty.Register("Describe", typeof(string), typeof(DescribeUserControl));

        /// <summary>
        /// 描述的textbox的输入值
        /// </summary>
        public string DescribeValue
        {
            get { return (string)GetValue(DescribeValueProperty); }
            set { SetValue(DescribeValueProperty, value); }
        }

        public static readonly DependencyProperty DescribeValueProperty =
            DependencyProperty.Register("DescribeValue", typeof(string), typeof(DescribeUserControl));

        /// <summary>
        /// X1
        /// </summary>
        public double X1
        {
            get { return (double)GetValue(X1Property); }
            set { SetValue(X1Property, value); }
        }

        public static readonly DependencyProperty X1Property =
            DependencyProperty.Register("X1", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// Y1
        /// </summary>
        public double Y1
        {
            get { return (double)GetValue(Y1Property); }
            set { SetValue(Y1Property, value); }
        }

        public static readonly DependencyProperty Y1Property =
            DependencyProperty.Register("Y1", typeof(double), typeof(DescribeUserControl));
        /// <summary>
        /// X2
        /// </summary>
        public double X2
        {
            get { return (double)GetValue(X2Property); }
            set { SetValue(X2Property, value); }
        }

        public static readonly DependencyProperty X2Property =
            DependencyProperty.Register("X2", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// Y2
        /// </summary>
        public double Y2
        {
            get { return (double)GetValue(Y2Property); }
            set { SetValue(Y2Property, value); }
        }

        public static readonly DependencyProperty Y2Property =
            DependencyProperty.Register("Y2", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// X3
        /// </summary>
        public double X3
        {
            get { return (double)GetValue(X3Property); }
            set { SetValue(X3Property, value); }
        }

        public static readonly DependencyProperty X3Property =
            DependencyProperty.Register("X3", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// Y3
        /// </summary>
        public double Y3
        {
            get { return (double)GetValue(Y3Property); }
            set { SetValue(Y3Property, value); }
        }

        public static readonly DependencyProperty Y3Property =
            DependencyProperty.Register("Y3", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// X4
        /// </summary>
        public double X4
        {
            get { return (double)GetValue(X4Property); }
            set { SetValue(X4Property, value); }
        }

        public static readonly DependencyProperty X4Property =
            DependencyProperty.Register("X4", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// Y4
        /// </summary>
        public double Y4
        {
            get { return (double)GetValue(Y4Property); }
            set { SetValue(Y4Property, value); }
        }

        public static readonly DependencyProperty Y4Property =
            DependencyProperty.Register("Y4", typeof(double), typeof(DescribeUserControl));

        /// <summary>
        /// 点去覆盖线的颜色，需要和大背景相同
        /// </summary>
        public Color ColorOverlay
        {
            get { return (Color)GetValue(ColorOverlayProperty); }
            set { SetValue(ColorOverlayProperty, value); }
        }

        public static readonly DependencyProperty ColorOverlayProperty =
            DependencyProperty.Register("ColorOverlay", typeof(Color), typeof(DescribeUserControl));
        #endregion

        public DescribeUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MyStackPanel.Margin = new Thickness(X1, Y1, 0, 0);
            MyLine1.X1 = X2;
            MyLine1.Y1 = Y2;
            MyLine1.X2 = MyLine2.X1 = X3;
            MyLine1.Y2 = MyLine2.Y1 = Y3;
            MyLine2.X2 = X4;
            MyLine2.Y2 = Y4;
            MyDoubleEllipse.Margin = new Thickness(X4 - 10, Y4 + 5, 0, 0);
            MyStackPanel.Background = new SolidColorBrush(ColorOverlay);
        }
    }
}
