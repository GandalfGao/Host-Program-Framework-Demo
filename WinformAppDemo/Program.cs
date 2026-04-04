using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformAppDemo
{
    internal static class Program
    {
        private static Mutex mutex;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //唯一的互斥锁名称
            const string mutexName = "CCFB25405";
            //创建互斥锁对象
            mutex = new Mutex(true, mutexName, out bool createdNew);

            if (!createdNew)
            {
                //如果互斥锁对象已经存在, 说明程序已经运行
                var currProcess = Process.GetCurrentProcess();

                //查找已经运行的进程
                foreach (var process in Process.GetProcessesByName(currProcess.ProcessName))
                {
                    if (process.Id != currProcess.Id)
                    {
                        MessageBox.Show("程序已运行", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                }

                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            finally
            {
                //释放互斥锁对象
                mutex.ReleaseMutex();
                mutex.Close();
            }
        }
    }
}
