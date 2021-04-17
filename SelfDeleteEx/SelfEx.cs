namespace SelfDeleteEx
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /* Универсальный способ самоудаления программы
       Разработал: r3xq1
       --------------------------------------------------------------------------------------------------------
       Пример использования:

        public static string AssemblyPath => Assembly.GetExecutingAssembly().Location;
        public static string GetFileName => Path.GetFileName(AppDomain.CurrentDomain.FriendlyName);
        public static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string SelfHelper => Path.Combine(AppData, "Self.bat");

        SelfEx.CmdInit($"/C choice /C Y /N /D Y /T 0 &Del {GlobalPaths.AssemblyPath}", "cmd.exe");
        SelfEx.BatInit(SelfHelper, AssemblyPath);
     */

    public static class SelfEx
    {
        public static void CmdInit(string args, string commands)
        {
            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = commands,
                    Arguments = args,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };
                using var process = new Process { StartInfo = info };
                process?.Start();
                process.Refresh();
            }
            catch { }
        }

        public static void BatInit(string pathFile, string localpath)
        {
            if (!string.IsNullOrWhiteSpace(pathFile) && pathFile.EndsWith(".bat", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    using var sw = new StreamWriter(pathFile, false);
                    // sw.WriteLine($"@echo off\r\nchcp 1251 >NUL\r\ncls\r\n:loop\r\ndel \"{localpath}\"if Exist \"{localpath}\" GOTO loop del %0");
                    sw.WriteLine("chcp 1251 >NUL");
                    sw.WriteLine("cls");
                    sw.WriteLine(":loop");
                    sw.WriteLine($"del \"{localpath}\"");
                    sw.WriteLine($"if Exist \"{localpath}\" GOTO loop");
                    sw.WriteLine("del %0");
                    sw.Flush();
                }
                catch { }
                try
                {
                    var info = new ProcessStartInfo { FileName = pathFile, WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true };
                    using var process = new Process { StartInfo = info }; process?.Start(); process.Refresh();
                }
                catch { }
            }
            CmdInit($"/C choice /C Y /N /D Y /T 0 &Del {GlobalPaths.AssemblyPath}", "cmd.exe");
        }
    }
}