using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace 代码测试.ExcelHelper
{
    /// <summary>
    /// 描述：excel帮助类
    /// 用法：
    /// List<TestResult> l = new List<TestResult>();
    //var r = new ExcelHelper.TestResult();
    //r.SN = "dadada";
    //        r.SerialTest = "adadada";
    //        var r1 = new ExcelHelper.TestResult();
    //r1.SN = "dadada";
    //        r1.SerialTest = "adadada";
    //        l.Add(r);
    //        l.Add(r1);
    //        Helper e = new Helper();
    //var w = e.CreateOrOpen(@"C:\Users\DELL\Desktop\1.xlsx");
    //e.Add(w, l);
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class Helper
    {
        private Application app;
        private string filePath;
        public _Workbook CreateOrOpen(string filePath)
        {
            app = new Application();
            Workbooks wbks = app.Workbooks;
            this.filePath = filePath;
            _Workbook _wbk = wbks.Add();
            return _wbk;
        }

        public void Add(_Workbook _wbk,List<TestResult> list) 
        {
            _wbk.Worksheets.Add();
            _Worksheet _wsh = (_Worksheet)_wbk.Worksheets[1];
            var l = list[0];
            var names = l.GetType().GetProperties();
            var _cell = _wsh.Cells[1, 1]; //单元格区域也从1,1开始，[row, column]
            var _range = _wsh.Range[_wsh.Cells[1, 1], _wsh.Cells[100, 100]]; //从1,1到100,100的单元格区域

            for (int i = 0; i < names.Length; i++)
            {
                // 写表头
                _range[1, i + 1] = names[i].Name.ToString();
            }
            for (int j = 2; j <= list.Count + 1; j++)
            {
                for (int k = 0; k < names.Length; k++)
                {
                    try
                    {
                        var ds = _wsh.Cells[1, k + 1].Text;
                        // "\t"主要是为了处理掉科学计数法带来的缩写
                        _range[j, k + 1] = "\t" + TranslateData(list[j - 2].GetValue(ds));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
            // 转义一次表头
            for (int i = 0; i < names.Length; i++)
            {
                // 写表头
                _range[1, i + 1] = TranslateHeader(names[i].Name.ToString());
            }
            // 自适应列宽
            _wsh.Cells.Select();
            _wsh.Cells.Columns.AutoFit();
            app.DisplayAlerts = false;
            _wbk.SaveAs(filePath);//如果是打开一个已经存在的文件，直接保存。
            _wbk.Close(); //关闭文件；
            app.Quit(); //关闭excel程序，不运行会有进程残留，并占据文件，导致后续打开无法编辑
            System.Windows.MessageBox.Show("写入成功");
        }

        /// <summary>
        ///  翻译表头
        /// </summary>
        /// <returns></returns>
        public string TranslateHeader(string str)
        {
            string result = string.Empty;
            switch (str)
            {
                case "ID":
                    result = "ID";
                    break;
                case "SN":
                    result = "SN";
                    break;

                case "TestTime":
                    result = "测试时间";
                    break;

                case "AllItemResult":
                    result = "总的测试结果";
                    break;

                case "PowerOnTest":
                    result = "上电测试";
                    break;

                case "VersionTest":
                    result = "版本测试";
                    break;

                case "CVBSTest":
                    result = "CVBS测试";
                    break;

                case "CameraTest":
                    result = "摄像头测试";
                    break;

                case "LEDTest":
                    result = "LED测试";
                    break;

                case "LoudspeakerTest":
                    result = "喇叭测试";
                    break;

                case "DDRTest":
                    result = "DDR测试";
                    break;

                case "NandTest":
                    result = "NandTest测试";
                    break;

                case "GsensorTest":
                    result = "G-Senser测试";
                    break;

                case "MiniLCD5VTest":
                    result = "小屏测试";
                    break;

                case "SerialTest":
                    result = "串口测试";
                    break;

                case "RigidLineLeftTest":
                    result = "左转硬线测试";
                    break;

                case "RigidLineRightTest":
                    result = "右转硬线测试";
                    break;

                case "RigidLineBrakeTest":
                    result = "刹车硬线测试";
                    break;

                case "RigidLineSpeedTest":
                    result = "速度硬线测试";
                    break;

                case "CanBusTest0Test":
                    result = "CAN0测试";
                    break;
                case "CanBusTest1Test":
                    result = "CAN1测试";
                    break;
                case "VoltageTest":
                    result = "电压测试";
                    break;
                case "SDCardTest":
                    result = "SD卡测试";
                    break;
                case "ModeKeyTest":
                    result = "模式按键测试";
                    break;
                case "SeatVibrationOnTest":
                    result = "座椅振动测试";
                    break;
                default:
                    break;
            }
            return result;
        }

        public object TranslateData(object o)
        {
            string result = string.Empty;
            if (!(o is string))
            {
                return o;
            }
            try
            {
                switch (o.ToString())
                {
                    case "NonConfiged":
                        result = "未配置对应的测试";
                        break;
                    case "NonTested":
                        result = "未测试，跳过";
                        break;
                    case "Passed":
                        result = "通过";
                        break;
                    case "Failed":
                        result = "失败";
                        break;
                    default:
                        result = o.ToString();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
