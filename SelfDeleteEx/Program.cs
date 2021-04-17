namespace SelfDeleteEx
{
    using System;

    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Console.Title = "SelfDeleteEx by r3xq1";
            Console.WriteLine("Нажмите любую кнопку для закрытия и само удаление программы");
            Console.ReadLine();
            SelfEx.CmdInit($"/C choice /C Y /N /D Y /T 0 &Del {GlobalPaths.AssemblyPath}", "cmd.exe");
            SelfEx.BatInit(GlobalPaths.SelfHelper, GlobalPaths.AssemblyPath);
        }
    }
}