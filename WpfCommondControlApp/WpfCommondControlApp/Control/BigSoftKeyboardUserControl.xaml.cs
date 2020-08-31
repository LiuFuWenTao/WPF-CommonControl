using GalaSoft.MvvmLight.Command;
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
using WpfCommondControlApp.Helper;

namespace WpfCommondControlApp.Control
{
    /// <summary>
    /// BigSoftKeyboardUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class BigSoftKeyboardUserControl : System.Windows.Controls.UserControl
    {
        //1、声明并注册路由事件，使用冒泡策略
        public static readonly RoutedEvent MyClientEvent = EventManager.RegisterRoutedEvent("MyClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BigSoftKeyboardUserControl));
        //2、通过.NET事件包装路由事件
        public event RoutedEventHandler MyClick
        {
            add { AddHandler(MyClientEvent, value); }
            remove { RemoveHandler(MyClientEvent, value); }
        }

        public BigSoftKeyboardUserControl()
        {
            InitializeComponent();
            Loaded += BigSoftKeyboardUserControl_Loaded;
        }

        private void BigSoftKeyboardUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox.IsChecked = false;
            //初始化界面
            if (Win32Helper.CapsLockStatus)
            {
                InputCommand?.Execute("CapsLock");//恢复小写
            }
            Letter.Visibility = Visibility.Visible;
            Symbol.Visibility = Visibility.Collapsed;
            MoreOrReturn.IsChecked = false;
            MoreOrReturn.Content = "更多";
        }

        public ICommand InputCommand => new RelayCommand<string>(t =>
        {
            //--------------输入时注册路由事件
            RoutedEventArgs arg = new RoutedEventArgs();
            arg.RoutedEvent = MyClientEvent;
            RaiseEvent(arg);
            //--------------
            var c = t.ToCharArray();
            if (c[0].Equals('"'))//"这个没法用特殊字符来判断，界面写的是&quot;，传进来之后变成‘"’,所以在这做一个小转换
            {
                t = "&quot;";
            }
            switch (t)
            {
                case "0":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D0);
                    break;
                case "1":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D1);
                    break;
                case "2":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D2);
                    break;
                case "3":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D3);
                    break;
                case "4":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D4);
                    break;
                case "5":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D5);
                    break;
                case "6":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D6);
                    break;
                case "7":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D7);
                    break;
                case "8":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D8);
                    break;
                case "9":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D9);
                    break;
                case "q":
                case "Q":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Q);
                    break;
                case "w":
                case "W":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.W);
                    break;
                case "e":
                case "E":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.E);
                    break;
                case "r":
                case "R":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.R);
                    break;
                case "t":
                case "T":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.T);
                    break;
                case "y":
                case "Y":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Y);
                    break;
                case "u":
                case "U":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.U);
                    break;
                case "i":
                case "I":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.I);
                    break;
                case "o":
                case "O":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.O);
                    break;
                case "p":
                case "P":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.P);
                    break;
                case "a":
                case "A":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.A);
                    break;
                case "s":
                case "S":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.S);
                    break;
                case "d":
                case "D":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D);
                    break;
                case "f":
                case "F":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.F);
                    break;
                case "g":
                case "G":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.G);
                    break;
                case "h":
                case "H":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.H);
                    break;
                case "j":
                case "J":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.J);
                    break;
                case "k":
                case "K":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.K);
                    break;
                case "l":
                case "L":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.L);
                    break;
                case "z":
                case "Z":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Z);
                    break;
                case "x":
                case "X":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.X);
                    break;
                case "c":
                case "C":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.C);
                    break;
                case "v":
                case "V":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.V);
                    break;
                case "b":
                case "B":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.B);
                    break;
                case "n":
                case "N":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.N);
                    break;
                case "m":
                case "M":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.M);
                    break;
                case "CapsLock":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.CapsLock);
                    break;
                case "Backspace":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Back);
                    break;
                case "`":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemTilde);
                    break;
                case "~":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemTilde);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "!":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D1);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "@":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D2);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "#":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D3);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "$":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D4);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "%":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D5);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "^":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D6);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "&":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D7);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "*":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D8);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "_":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemMinus);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "-":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemMinus);
                    break;
                case "+":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Add);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "=":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemPlus);
                    break;
                case "<":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemComma);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case ">":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemPeriod);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "|":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Oem102);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "(":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D9);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case ")":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.D0);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "[":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemOpenBrackets);
                    break;
                case "]":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemCloseBrackets);
                    break;
                case " {":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemOpenBrackets);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "}":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemCloseBrackets);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case @"\":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Oem102);
                    break;
                case @"/":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemQuestion);
                    break;
                case ":":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemSemicolon);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case ";":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemSemicolon);
                    break;
                case "&quot;":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemQuotes);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;
                case "'":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemQuotes);
                    break;
                case ",":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemComma);
                    break;
                case ".":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemPeriod);
                    break;
                case "?":
                    Win32Helper.SendKeyPressDown(Key.LeftShift);
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.OemQuestion);
                    Win32Helper.SendKeyPressUp(Key.LeftShift);
                    break;

                case "Clear":
                    Win32Helper.SendKeyPressDown(Key.LeftCtrl);//按下ctrl
                    Win32Helper.SendKeyPressDown(Key.A);//同时按下a

                    Win32Helper.SendKeyPressUp(Key.LeftCtrl);
                    Win32Helper.SendKeyPressUp(Key.A);

                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Back);
                    break;
            }
        });

        public ICommand ChangeMoreOrReturn => new RelayCommand<string>(t =>
        {
            if (string.Equals("更多", MoreOrReturn.Content))
            {
                //点击更多按钮
                MoreOrReturn.Content = "返回";
            }
            else
            {
                //点击返回按钮
                MoreOrReturn.Content = "更多";

            }
        });

        public ICommand SwitchSymbolOrLetter => new RelayCommand<string>(t =>
        {
            if ("符号".Equals(t.ToString()))
            {
                //切换到符号键盘显示
                Letter.Visibility = Visibility.Collapsed;
                Symbol.Visibility = Visibility.Visible;
            }
            else
            {
                //切换到字母键盘显示
                Letter.Visibility = Visibility.Visible;
                Symbol.Visibility = Visibility.Collapsed;
                //回到默认值
                MoreOrReturn.IsChecked = false;
                MoreOrReturn.Content = "更多";
                CheckBox.IsChecked = false;
                if (Win32Helper.CapsLockStatus)
                {
                    InputCommand?.Execute("CapsLock");//恢复小写
                }
            }


        });
    }
}
