using Microsoft.Win32;

namespace BiligameAccountSwitchTool.Helpers
{
    internal abstract class IEVersionHelper
    {
        private static readonly Version _version;

        static IEVersionHelper()
        {
            _version = new Version((string)Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Internet Explorer")!.GetValue("svcVersion", "1.0.0.0"));
        }

        public static int GetBrowserEmulation(int majorVersion, bool mode)
        {
            int[] modes;
            switch (majorVersion)
            {
                case 8:
                    modes = new int[] { 8000, 8888 };
                    break;
                case 9:
                    modes = new int[] { 9000, 9999 };
                    break;
                case 10:
                    modes = new int[] { 10000, 10001 };
                    break;
                case 11:
                    modes = new int[] { 11000, 11001 };
                    break;
                default:
                    return 7000;
            }
            return mode ? modes[0] : modes[1];
        }

        public static int MajorVersion => _version.Major;
        public static int lastOverrideEmulationMode => GetBrowserEmulation(MajorVersion, true);
        public static Version Version => _version;
    }
}
