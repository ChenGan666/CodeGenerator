using System;

namespace ZSN.Utils.Core.Helpers
{
    public static class ConsoleHelper
    {
        #region 控制台日志

        public static void WriteInfoLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
        }

        public static void WriteSuccessLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
        }

        public static void WriteErrorLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
            Console.ResetColor();
        }

        #endregion
    }
}