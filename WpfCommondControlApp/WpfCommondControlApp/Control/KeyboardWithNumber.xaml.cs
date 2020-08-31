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
    /// KeyboardWithNumber.xaml 的交互逻辑
    /// </summary>
    public partial class KeyboardWithNumber : System.Windows.Controls.UserControl
    {
        public KeyboardWithNumber()
        {
            InitializeComponent();
        }

        public ICommand InputCommand => new RelayCommand<string>(t =>
        {
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
                case "Backspace":
                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Back);
                    break;
                case "Clear":
                    Win32Helper.SendKeyPressDown(Key.LeftCtrl);//按下ctrl
                    Win32Helper.SendKeyPressDown(Key.A);//同时按下a

                    Win32Helper.SendKeyPressUp(Key.LeftCtrl);
                    Win32Helper.SendKeyPressUp(Key.A);

                    Win32Helper.SendKeyByVirtualSoftKeyboard(Key.Back);
                    break;
                    break;
            }
        });
    }
}
