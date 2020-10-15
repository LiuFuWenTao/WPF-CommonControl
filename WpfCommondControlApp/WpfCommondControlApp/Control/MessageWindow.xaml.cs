// <copyright file="MessageWindow.xaml.cs" company="Autocruis">
//     Main window class
// </copyright>
// <summary>
// 消息窗口
// </summary>
// <author>Wenjie Li</author>
//-----------------------------------------------------------------------
namespace PCToolControl
{
    using System.Windows;

    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        /// <summary>
        /// 消息窗口的模式
        /// </summary>
        private MessageButton messageButtonType = MessageButton.OK;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageWindow"/> class.
        /// 消息窗口构造函数
        /// </summary>
        public MessageWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 消息窗口的模式的枚举
        /// </summary>
        public enum MessageButton
        {
            /// <summary>
            /// 仅显示消息
            /// </summary>
            OK,

            /// <summary>
            /// 带“是”和“否”按钮的消息窗口
            /// </summary>
            YesNo
        }

        /// <summary>
        /// Gets or sets 消息窗口标题
        /// </summary>
        public string Caption
        {
            get
            {
                return this.titleTB.Text;
            }

            set
            {
                this.titleTB.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets 显示的消息内容
        /// </summary>
        public string Message
        {
            get
            {
                return this.messageTB.Text;
            }

            set
            {
                this.messageTB.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets 消息框模式
        /// </summary>
        public MessageButton MessageButtonType
        {
            get
            {
                return this.messageButtonType;
            }

            set
            {
                this.messageButtonType = value;
                if (this.messageButtonType == MessageButton.OK)
                {
                    this.okBT.Visibility = Visibility.Visible;
                    this.yesBT.Visibility = Visibility.Collapsed;
                    this.noBT.Visibility = Visibility.Collapsed;
                }
                else if (this.messageButtonType == MessageButton.YesNo)
                {
                    this.okBT.Visibility = Visibility.Collapsed;
                    this.yesBT.Visibility = Visibility.Visible;
                    this.noBT.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// 显示消息窗口
        /// </summary>
        /// <param name="message">要显示的消息</param>
        public static void Show(string message)
        {
            Show(message, string.Empty, MessageButton.OK);
        }

        /// <summary>
        /// 显示消息窗口
        /// </summary>
        /// <param name="message">要显示的消息</param>
        /// <param name="caption">消息框的标题</param>
        public static void Show(string message, string caption)
        {
            Show(message, caption, MessageButton.OK);
        }

        /// <summary>
        /// 显示消息窗口
        /// </summary>
        /// <param name="message">要显示的消息</param>
        /// <param name="caption">消息框的标题</param>
        /// <param name="messageButtonType">消息框的类型</param>
        /// <returns>是否点击了“是”或者“确定”按钮</returns>
        public static bool? Show(string message, string caption, MessageButton messageButtonType)
        {
            MessageWindow messageWindow = new MessageWindow();
            messageWindow.Caption = caption;
            messageWindow.Message = message;
            messageWindow.MessageButtonType = messageButtonType;
            return messageWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Height = this.messageTB.ActualHeight + 10 + this.titleTB.ActualHeight + 60 + this.btPanel.Height;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
