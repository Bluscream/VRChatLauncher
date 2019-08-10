using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace VRChatLauncher.Utils
{
    public class ExternalConsole
    {
        private const int STD_OUTPUT_HANDLE = -11;  
        private const int MY_CODE_PAGE = 437;  

        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]  
        private static extern IntPtr GetStdHandle(int nStdHandle);  
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]  
        private static extern int AllocConsole();  
        [DllImport("kernel32.dll", EntryPoint = "FreeConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]  
        private static extern int FreeConsole();  
 
        public static void InitConsole()
        {                
            AllocConsole();  
            IntPtr stdHandle=GetStdHandle(STD_OUTPUT_HANDLE);  
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);  
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);  
            Encoding encoding = Encoding.GetEncoding(MY_CODE_PAGE);  
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);  
            standardOutput.AutoFlush = true;  
            Console.SetOut(standardOutput);  
         }  
        public static void Dispose()
        {
            FreeConsole();
        }
    }
}
