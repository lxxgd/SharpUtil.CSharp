using System.Runtime.InteropServices;

namespace SharpUtil.Runtime
{
    public class NativeLibraries
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDefaultDllDirectories(int directoryFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern void AddDllDirectory(string lpPathName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDllDirectory(string lpPathName);

        public static void SetNativeLibraryPath(string nativesDir)
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }
            try
            {
                SetDefaultDllDirectories(4096);
                AddDllDirectory(nativesDir);
            }
            catch
            {
                SetDllDirectory(nativesDir);
            }
        }
    }
}
