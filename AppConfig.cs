using BiligameAccountSwitchTool.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BiligameAccountSwitchTool
{
    internal static class AppConfig
    {
        public static string DataPath { get; private set; }
        public const string RepoLink = "https://github.com/Fachep/BiligameAccountSwitchTool";
        public const string AppShortName = "BASTool";
        public const string AppLongName = "BiligameAccountSwitchTool";
        public const string AppDescription = """
            Bilibili服PC游戏账号切换器
            支持使用Biligame PCGameSDK < 4.0作为登录接口的游戏账号切换。
            依赖：
                .NET 7
                Internet Explorer >= 9
            内置支持的游戏：
                原神（hk4e）
                崩坏：星穹铁道（hkrpg）

            """;

        private static IServiceProvider? _serviceProvider;
        private readonly static AssemblyName _assemblyName;

        public static Version? AppVersion => _assemblyName.Version;
        public static string? AppName => _assemblyName.Name;

        static AppConfig()
        {
#if DEBUG
            DataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
#else
            DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BASTool");
#endif
            _assemblyName = typeof(AppConfig).Assembly.GetName();
            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);
        }

        public static void ResetServiceProvider()
        {
            _serviceProvider = null;
        }

        private static void BuildServiceProvider()
        {
            if (_serviceProvider != null) return;
            var sc = new ServiceCollection();
            //sc.AddLogging(c => c.AddSimpleConsole(c => c.TimestampFormat = "[HH:mm:ss]"));
#if DEBUG
            //sc.AddLogging(c => c.AddDebug());
#endif
            sc.AddSingleton(p => new DatabaseService(DataPath));
            sc.AddSingleton<GameService>();
            sc.AddTransient<AccountService>();

            _serviceProvider = sc.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            if (_serviceProvider == null) BuildServiceProvider();
            return _serviceProvider!.GetService<T>()!;
        }
    }
}
