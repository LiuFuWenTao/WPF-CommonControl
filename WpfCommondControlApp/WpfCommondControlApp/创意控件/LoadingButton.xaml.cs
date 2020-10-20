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

namespace 代码测试.创意控件
{
    /// <summary>
    /// LoadingButton.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingButton : UserControl
    {
        #region 依赖项属性
        /// <summary>
        /// 是否处于加载中
        /// </summary>
        public bool IsOnLoading
        {
            get { return (bool)GetValue(IsOnLoadingProperty); }
            set { SetValue(IsOnLoadingProperty, value);
                // 是否处于加载中状态，处于则是显示加载中动画，不处于则显示加载完成动画
                if (value)
                {
                    loading.Visibility = Visibility.Visible;
                    loadingComplete.Visibility = Visibility.Collapsed;
                }
                else
                {
                    loading.Visibility = Visibility.Collapsed;
                    loadingComplete.Visibility = Visibility.Visible;
                }
            }
        }

        public static readonly DependencyProperty IsOnLoadingProperty =
            DependencyProperty.Register("IsOnLoading", typeof(bool), typeof(Loading)
                ,new PropertyMetadata(true,null, IsOnLoadingChange));

        private static object IsOnLoadingChange(DependencyObject d, object baseValue)
        {
            bool f = (bool)baseValue;
            //if (f)
            //{
            //    loading.Visibility = Visibility.Visible;
            //    loadingComplete.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    loading.Visibility = Visibility.Collapsed;
            //    loadingComplete.Visibility = Visibility.Visible;
            //}
            return baseValue;
        }

        #endregion
        public LoadingButton()
        {
            InitializeComponent();
        }
    }
}
