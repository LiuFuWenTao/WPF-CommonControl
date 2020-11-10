using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using 代码测试.Model;

namespace 代码测试
{
    /// <summary>
    /// 基于path做的圆弧形控件
    /// 使用方法： <local:VolumeUserControl x:Name="myUc" Height="400" Width="400" X0="30" Y0="130" R="100"/>
    /// 在这个控件的PercentageData属性赋值list<PercentageData>即可控制
    /// 点坐标计算公式
    /// x1 = x0+r-(r*COS(A))
    /// y1 = y0 + r*SIN(A)
    /// VolumeUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ArcDiagramUserControl : UserControl
    {
        #region 依赖属性
        /// <summary>
        /// 起点是（10,110）画半径为100的圆
        /// 由外界传入的数据实体
        /// 结构是PercentageData
        /// 会根据这个算出比例，在完整的圆形控件中按比例显示
        /// </summary>
        public List<PercentageData> PercentageData
        {
            get { return (List<PercentageData>)GetValue(this.PercentageDataProperty); }
            set
            {
                SetValue(this.PercentageDataProperty, value);
            }
        }
        public readonly DependencyProperty PercentageDataProperty =
            DependencyProperty.Register("PercentageData", typeof(List<PercentageData>), typeof(ArcDiagramUserControl));

        public int X0
        {
            get { return (int)GetValue(X0Property); }
            set { SetValue(X0Property, value); }
        }

        public readonly DependencyProperty X0Property =
            DependencyProperty.Register("X0", typeof(int), typeof(ArcDiagramUserControl));
        public int Y0
        {
            get { return (int)GetValue(Y0Property); }
            set { SetValue(Y0Property, value); }
        }

        public readonly DependencyProperty Y0Property =
            DependencyProperty.Register("Y0", typeof(int), typeof(ArcDiagramUserControl));
        public int R
        {
            get { return (int)GetValue(RProperty); }
            set { SetValue(RProperty, value); }
        }

        public readonly DependencyProperty RProperty =
            DependencyProperty.Register("R", typeof(int), typeof(ArcDiagramUserControl));
        #endregion


        #region 成员变量
        private double _TotalValue;
        #endregion
        public ArcDiagramUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画界面
        /// </summary>
        private void DrawView()
        {
            //终点x
            double x1 = 0;
            //终点y
            double y1 = 0;
            //终点x
            double last_x = X0;
            //终点y
            double last_y = Y0;
            double last_A = 0;
            foreach (var item in PercentageData)
            {
                Path p = new Path();
                p.Stroke = item.Color;
                p.StrokeDashCap = PenLineCap.Square;
                p.StrokeThickness = item.Borderness;
                // 角度
                double A = (double)(360 * item.Value / _TotalValue);
                // 是否最优弧
                var f = A > 180 ? 1 : 0;
                double angle = (Math.PI / 180.0)*(A+ last_A);
                x1 = X0 + R - (R * Math.Cos(angle));
                y1 = Y0 + R * Math.Sin(angle);
                var converter = TypeDescriptor.GetConverter(typeof(Geometry));
                p.Data = (Geometry)(converter.ConvertFrom(string.Format("M {0},{1} A 100,100 0 {2} 0 {3},{4}", last_x, last_y, f , x1,y1)));
                myGrid.Children.Add(p);
                last_x = x1;
                last_y = y1;
                last_A += A;
            }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        private double GetTotalValue()
        {
            if(PercentageData == null)
            {
                Console.WriteLine("记录一下，这个传入的值为空");
                return 0;
            }
            double reslut = 0;
            foreach(var item in PercentageData)
            {
                reslut += item.Value;
            }
            return reslut;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _TotalValue = GetTotalValue();
            DrawView();
        }
    }
}
