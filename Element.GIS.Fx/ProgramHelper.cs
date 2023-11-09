using Avalonia.Themes.Neumorphism.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Element.GIS.Fx
{
    public static class ProgramHelper
    {
        public static void StartProcess(string module, string exeName, string args)
        {
            AppDomain domain = AppDomain.CurrentDomain;
            var exePath = Path.Combine(domain.BaseDirectory, "Modules", module, exeName);
            if (File.Exists(exePath))
            {
                StartProcess(exePath, args);
            }
            else
            {
                SnackbarHost.Post($"Module:{module}, {exeName} not exists!");
            }
        }

        public static void StartProcess(string exePath, string args)
        {
            using (Process proc = new Process())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(exePath);
                proc.StartInfo.FileName = exePath;
                proc.StartInfo.Arguments = args;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                //proc.StartInfo.CreateNoWindow = true;//不显示程序窗口
                proc.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                proc.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                proc.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                proc.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                proc.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                proc.Start();//启动程序

                proc.StandardInput.AutoFlush = true;
                proc.WaitForExit();
                stopwatch.Stop();
                Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ",共耗时:" + stopwatch.ElapsedMilliseconds / 1000d + "s");
                var msg = proc.StandardOutput.ReadToEnd();
                var logOut = Path.Combine(Path.GetDirectoryName(exePath), "Output");
                Directory.CreateDirectory(logOut);
                var logOutFile = Path.Combine(logOut, "output.txt");
                FileStream newFs = new FileStream(logOutFile, FileMode.Create);
                StreamWriter sw = new StreamWriter(newFs, Encoding.ASCII);
                sw.Write(DateTime.Now);
                sw.Write(msg);
                sw.Flush();
                sw.Close();
                newFs.Close();
                proc.Close();
            };
        }
    }
}
