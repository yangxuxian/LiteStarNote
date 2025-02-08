using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using LiteStarNote;

namespace LiteStarNote
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string lockFilePath = Path.Combine(Path.GetTempPath(), "LiteStarNoteApp.lock");
            FileStream lockFile = null;
            try
            {
                // �����Զ�ռ��ʽ���ļ�
                lockFile = new FileStream(lockFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                ApplicationConfiguration.Initialize();
                Application.Run(new LiteStarNoteForm());
            }
            catch (IOException)
            {
                // �жϵ�ǰϵͳ�Ƿ�Ϊ Windows
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    ActivateExistingInstanceOnWindows();
                }
                else {
                    MessageBox.Show("�����Ѿ���������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                lockFile?.Close();
            }
        }


        static void ActivateExistingInstanceOnWindows()
        {
            try
            {
                string currentProcessName = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(currentProcessName);

                foreach (Process process in processes)
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        IntPtr hWnd = process.MainWindowHandle;
                        if (hWnd == IntPtr.Zero)
                        {
                            hWnd = FindWindow(null, "���Ǳ�ǩ v1.1");
                        }
                        if (hWnd != IntPtr.Zero)
                        {
                            ShowWindow(hWnd, 1);
                            SetForegroundWindow(hWnd);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error activating existing instance: {ex.Message}");
            }
        }

    }
}