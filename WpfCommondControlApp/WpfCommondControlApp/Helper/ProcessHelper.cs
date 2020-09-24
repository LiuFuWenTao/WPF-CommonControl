using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCommondControlApp.Helper
{
    /// <summary>
    /// 描述：
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public static class ProcessHelper
    {
        /// <summary>
        /// 判断进程是否正在运行中
        /// </summary>
        /// <param name="name">进程名字</param>
        /// <returns>是否正常运行</returns>
        public static bool ProcessIsRun(string name)
        {
            bool reslut = false;
            if (Process.GetProcessesByName(name).ToList().Count > 0)
            {
                reslut = true;
            }

            return reslut;
        }
        /// <summary>
        /// 杀掉XXXX进程
        /// </summary>
        /// <param name="strProcessesByName">进程名称，不带.exe</param>
        public static void KillProcess(string processName)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains(processName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                        Console.WriteLine($"已杀掉{processName}进程！！！");
                    }
                    catch (Win32Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                }

            }
        }
    }
}
