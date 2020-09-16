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

namespace WpfCommondControlApp.Control
{
    /// <summary>
    /// MoveLineByKeyboardOrMouse.xaml 的交互逻辑
    /// </summary>
    public partial class MoveLineByKeyboardOrMouse : UserControl
    {
        public MoveLineByKeyboardOrMouse()
        {
            InitializeComponent();
        }

        #region 矩形移动的鼠标方法
        public LineType _lineType;
        public bool _topIsSelect;
        public bool _leftIsSelect;
        public bool _rightIsSelect;
        private Color _selectColor = Color.FromArgb(255, 241, 25, 74);
        private Color _unSelectColor = Color.FromArgb(255, 0, 255, 209);
        private int _step = 5;
        private int _minWidth = 50;
        private int _maxWidth = 500;
        private int _minHeight = 50;
        private int _maxHeight = 500;
        /// <summary>
        /// 选中top线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lineType = LineType._Top;
            SetSeclectChange(_lineType);
        }
        /// <summary>
        /// 选中左边线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Left_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lineType = LineType._Left;
            SetSeclectChange(_lineType);
        }
        /// <summary>
        /// 选中右边线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lineType = LineType._Right;
            SetSeclectChange(_lineType);
        }
        /// <summary>
        /// 线的枚举
        /// </summary>
        public enum LineType
        {
            _Top = 0,
            _Left,
            _Right
        }
        /// <summary>
        /// 选中之后的可移动性的变化
        /// </summary>
        /// <param name="type"></param>
        private void SetSeclectChange(LineType type)
        {
            switch (type)
            {
                case LineType._Top:
                    _topIsSelect = true;
                    _leftIsSelect = false;
                    _rightIsSelect = false;
                    Top.Stroke = new SolidColorBrush(_selectColor);
                    Left.Stroke = new SolidColorBrush(_unSelectColor);
                    Right.Stroke = new SolidColorBrush(_unSelectColor);
                    break;
                case LineType._Left:
                    _topIsSelect = false;
                    _leftIsSelect = true;
                    _rightIsSelect = false;
                    Top.Stroke = new SolidColorBrush(_unSelectColor);
                    Left.Stroke = new SolidColorBrush(_selectColor);
                    Right.Stroke = new SolidColorBrush(_unSelectColor);
                    break;
                case LineType._Right:
                    _topIsSelect = false;
                    _leftIsSelect = false;
                    _rightIsSelect = true;
                    Top.Stroke = new SolidColorBrush(_unSelectColor);
                    Left.Stroke = new SolidColorBrush(_unSelectColor);
                    Right.Stroke = new SolidColorBrush(_selectColor);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 键盘监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _CanvasBackGround_KeyDown(object sender, KeyEventArgs e)
        {
            switch (_lineType)
            {
                case LineType._Top:
                    if (e.Key == Key.Up)
                    {
                        if (Top.Y1 - _step < _minHeight)
                        {
                            return;
                        }
                        Top.Y1 = Top.Y2 -= _step;
                        Left.Y1 -= _step;
                        Right.Y1 -= _step;
                    }
                    else if (e.Key == Key.Down)
                    {
                        if (Top.Y1 + _step > _maxHeight)
                        {
                            return;
                        }
                        Top.Y1 = Top.Y2 += _step;
                        Left.Y1 += _step;
                        Right.Y1 += _step;
                    }
                    break;
                case LineType._Left:
                    if (e.Key == Key.Left)
                    {
                        if (Left.X1 - _step < _minWidth)
                        {
                            return;
                        }
                        Left.X1 = Left.X2 -= _step;
                        Top.X1 -= _step;
                    }
                    else if (e.Key == Key.Right)
                    {
                        if (Left.X1 + _step > _maxWidth)
                        {
                            return;
                        }
                        Left.X1 = Left.X2 += _step;
                        Top.X1 += _step;
                    }
                    break;
                case LineType._Right:
                    if (e.Key == Key.Left)
                    {
                        if (Right.X1 - _step < _minWidth)
                        {
                            return;
                        }
                        Right.X1 = Right.X2 -= _step;
                        Top.X2 -= _step;
                    }
                    else if (e.Key == Key.Right)
                    {
                        if (Right.X1 + _step > _maxWidth)
                        {
                            return;
                        }
                        Right.X1 = Right.X2 += _step;
                        Top.X2 += _step;
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 左键放开事件，放开之后鼠标移动不触发线的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _topIsSelect = false;
            _leftIsSelect = false;
            _rightIsSelect = false;
        }
        /// <summary>
        /// 鼠标移动事件，左键按住的时候可用使线跟随
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            switch (_lineType)
            {
                case LineType._Top:
                    if (_topIsSelect)
                    {
                        Point mousePoint = e.GetPosition(this._CanvasBackGround);
                        if (mousePoint.Y > _maxHeight || mousePoint.Y < _minHeight)
                        {
                            return;
                        }
                        Top.Y1 = mousePoint.Y;
                        Top.Y2 = mousePoint.Y;
                        this.Left.Y1 = mousePoint.Y;
                        this.Right.Y1 = mousePoint.Y;
                        Console.WriteLine(mousePoint.X + "|" + mousePoint.Y);
                    }
                    break;
                case LineType._Left:
                    if (_leftIsSelect)
                    {
                        Point mousePoint = e.GetPosition(this._CanvasBackGround);
                        if (mousePoint.X > _maxWidth || mousePoint.X < _minWidth)
                        {
                            return;
                        }
                        Left.X1 = mousePoint.X;
                        Left.X2 = mousePoint.X;
                        Top.X1 = mousePoint.X;
                    }
                    break;
                case LineType._Right:
                    if (_rightIsSelect)
                    {
                        Point p = e.GetPosition(_CanvasBackGround);
                        if (p.X > _maxWidth || p.X < _minWidth)
                        {
                            return;
                        }
                        Right.X1 = p.X;
                        Right.X2 = p.X;
                        Top.X2 = p.X;
                    }
                    break;
                default:
                    break;
            }
        }

        public void CallKeyDown(KeyEventArgs e)
        {
            this._CanvasBackGround_KeyDown(null, e);
        }
        #endregion

        private void _CanvasBackGround_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Top.Focus();
        }
    }
}
