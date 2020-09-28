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
using System.Windows.Threading;

namespace 代码测试.Control
{
    /// <summary>
    /// 修改为可以根据大小调整的控件，不过设置的大小要注意设置为正方形
    /// 例
    //<uc1:LoadingWait x:Name="_loading" Height="150" Width="150" Visibility="Visible" Tag="Loading..."
    //                         UserControlContent="我正在加载..." Foreground="#FFE3953D" EllipseColor="#FF007BE5"
    //                         FontSize="14"/>
    /// </summary>
    /// <summary>  
    /// Interaction logic for LoadingWait.xaml  
    /// </summary>  
    public partial class LoadingWait : UserControl
    {
        #region 依赖性属性
        /// <summary>
        /// 中间加载的文字
        /// </summary>
        public string UserControlContent
        {
            get { return (string)GetValue(UserControlContentProperty); }
            set { SetValue(UserControlContentProperty, value); }
        }

        public static readonly DependencyProperty UserControlContentProperty =
            DependencyProperty.Register("UserControlContent", typeof(string), typeof(LoadingWait));

        public Color EllipseColor
        {
            get { return (Color)GetValue(EllipseColorProperty); }
            set { SetValue(EllipseColorProperty, value); }
        }

        public static readonly DependencyProperty EllipseColorProperty =
            DependencyProperty.Register("EllipseColor", typeof(Color), typeof(LoadingWait));
        #endregion

        #region Data  
        private readonly DispatcherTimer animationTimer;
        /// <summary>
        /// 半径
        /// </summary>
        private double r;
        #endregion

        #region Constructor  
        public LoadingWait()
        {
            InitializeComponent();

            animationTimer = new DispatcherTimer(
                DispatcherPriority.ContextIdle, Dispatcher);
            animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 90);
        }
        #endregion

        #region Private Methods  
        private void Start()
        {
            animationTimer.Tick += HandleAnimationTick;
            animationTimer.Start();
        }

        private void Stop()
        {
            animationTimer.Stop();
            animationTimer.Tick -= HandleAnimationTick;
        }

        private void HandleAnimationTick(object sender, EventArgs e)
        {
            SpinnerRotate.Angle = (SpinnerRotate.Angle + 36) % 360;
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            const double offset = Math.PI;
            const double step = Math.PI * 2 / 10.0;
            r = this.MyUc.ActualWidth / 2;
            MyCanvas.Width = this.MyUc.ActualWidth + C0.Width;
            MyCanvas.Height = this.MyUc.ActualHeight + C0.Height;
            SetPosition(C0, offset, 0.0, step);
            SetPosition(C1, offset, 1.0, step);
            SetPosition(C2, offset, 2.0, step);
            SetPosition(C3, offset, 3.0, step);
            SetPosition(C4, offset, 4.0, step);
            SetPosition(C5, offset, 5.0, step);
            SetPosition(C6, offset, 6.0, step);
            SetPosition(C7, offset, 7.0, step);
            SetPosition(C8, offset, 8.0, step);
        }

        private void SetPosition(Ellipse ellipse, double offset,
            double posOffSet, double step)
        {
            ellipse.SetValue(Canvas.LeftProperty, r
                + Math.Sin(offset + posOffSet * step) * r);

            ellipse.SetValue(Canvas.TopProperty, r
                + Math.Cos(offset + posOffSet * step) * r);
        }

        private void HandleUnloaded(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void HandleVisibleChanged(object sender,
            DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = (bool)e.NewValue;

            if (isVisible)
                Start();
            else
                Stop();
        }
        #endregion
    }
}
