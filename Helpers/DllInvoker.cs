using System.Runtime.InteropServices;

namespace BASTool.Helpers
{
    internal class DllInvoker
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        private readonly IntPtr _hModule;

        public DllInvoker(string lpFileName)
        {
            _hModule = LoadLibrary(lpFileName);
        }

        ~DllInvoker()
        {
            if (_hModule != IntPtr.Zero) FreeLibrary(_hModule);
        }

        public bool Loaded => _hModule != IntPtr.Zero;

        public Delegate? Invoker(string procName, Type t)
        {
            if (_hModule == IntPtr.Zero) return null;
            return Marshal.GetDelegateForFunctionPointer(GetProcAddress(_hModule, procName), t);
        }
    }
}
