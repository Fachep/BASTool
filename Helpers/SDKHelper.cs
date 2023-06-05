using System.IO.Compression;
using System.Security.Cryptography;

namespace BiligameAccountSwitchTool.Helpers
{
    internal class SDKHelper
    {
        private const string SDKZipURL = "https://webstatic.mihoyo.com/upload/operation_location/2022/03/24/1f0f2988a4dce2ffde7a9bf2cf03f70a_6649586421998027419.zip";
        private const string SDKZipEntry = "YuanShen_Data/Plugins/";
        private const string SDKFileName = "PCGameSDK.dll";
        private const string SDKZipMD5 = "1f0f2988a4dce2ffde7a9bf2cf03f70a";
        private const string SDKFileMD5 = "6f19870806a2ea2c41565ebb89f3e73d";
        private static readonly Version SDKVersion = new("3.5.0");
        //https://sdk-static.mihoyo.com/hk4e_cn/mdk/launcher/api/resource?key=KAtdSsoQ&launcher_id=17&channel_id=14

        private readonly IntPtr _hwnd;
        private readonly int _gameId;
        private readonly string _appKey;
        private DllInvoker? _sdkInvoker;

        private delegate int SDKInitDelegate(string szGameId, IntPtr hwndParent);
        private delegate int SDKShowLoginPanelDelegate(string szAppKey, bool bBackToLogin, LoginCallbackDelegate CallBack);
        private delegate int SDKLogoutDelegate();

        public delegate void LoginCallbackDelegate(string buf, int buflen);

        private SDKInitDelegate? SDKInit;
        private SDKShowLoginPanelDelegate? SDKShowLoginPanel;
        private SDKLogoutDelegate? SDKLogout;

        public SDKHelper(IntPtr hwnd, int gameId, string appKey)
        {
            _hwnd = hwnd;
            _gameId = gameId;
            _appKey = appKey;
        }

        public bool Loaded => _sdkInvoker?.Loaded == true;

        public int Load()
        {
            if (Loaded) return 0;
            if (!File.Exists(Path.Combine(AppConfig.DataPath, SDKFileName))) throw new FileNotFoundException();
            _sdkInvoker = new DllInvoker(Path.Combine(AppConfig.DataPath, SDKFileName));
            if (!_sdkInvoker.Loaded) throw new FileLoadException();
            SDKInit = (SDKInitDelegate?)_sdkInvoker.Invoker("SDKInit", typeof(SDKInitDelegate));
            SDKShowLoginPanel = (SDKShowLoginPanelDelegate?)_sdkInvoker.Invoker("SDKShowLoginPanel", typeof(SDKShowLoginPanelDelegate));
            SDKLogout = (SDKLogoutDelegate?)_sdkInvoker.Invoker("SDKLogout", typeof (SDKLogoutDelegate));
            if (SDKInit == null || SDKShowLoginPanel == null || SDKLogout == null)
            {
                _sdkInvoker = null;
                throw new FileLoadException();
            }
            return SDKInit(_gameId.ToString(), _hwnd);
        }

        public int ShowPanel(LoginCallbackDelegate callback)
        {
            if (!Loaded) return -1;
            SDKLogout!();
            return SDKShowLoginPanel!(_appKey, true, callback);
        }

        public static class DownloadSDK
        {
            private static CancellationTokenSource? cancelSource;

            public static bool Downloading = false;
            public delegate void ErrorDelegate(string message);
            public delegate void CompleteDelegate();
            public static event ErrorDelegate? OnError;
            public static event CompleteDelegate? OnComplete;

            public static void Start()
            {
                new Task(async () => await GetSDKAsync()).Start();
            }

            public static void Stop()
            {
                cancelSource?.Cancel();
                Downloading = false;
            }

            private static bool CheckFile(byte[] src, string checksum)
            {
                var hashData = MD5.HashData(src);
                var result = string.Join(null, hashData.Select(x => x.ToString("x2")));
                return result == checksum;
            }

            private static async Task GetSDKAsync()
            {
                try
                {
                    cancelSource?.Cancel();
                    cancelSource = new CancellationTokenSource();
                    Downloading = true;

                    var zipData = await DownloadAsync();
                    if (cancelSource.IsCancellationRequested) throw new TaskCanceledException();
                    if (!CheckFile(zipData, SDKZipMD5)) throw new Exception("压缩文件校验失败");

                    var dllData = await DecompressAsync(zipData);
                    if (cancelSource.IsCancellationRequested) throw new TaskCanceledException();
                    if (!CheckFile(dllData, SDKFileMD5)) throw new Exception("DLL文件校验失败");

                    await File.WriteAllBytesAsync(Path.Combine(AppConfig.DataPath, SDKFileName), dllData, cancelSource.Token);
                    OnComplete?.Invoke();
                }
                catch (TaskCanceledException)
                {
                    Downloading = false;
                    cancelSource?.Cancel();
                }
                catch (Exception ex)
                {
                    Downloading = false;
                    cancelSource?.Cancel();
                    OnError?.Invoke(ex.Message);
                }
            }

            private static async Task<byte[]> DownloadAsync()
            {
                using var httpClient = new HttpClient();
                return await httpClient.GetByteArrayAsync(SDKZipURL, cancelSource!.Token);
            }

            private static async Task<byte[]> DecompressAsync(byte[] source)
            {
                using var srcStream = new MemoryStream(source);
                using var zipArchive = new ZipArchive(srcStream, ZipArchiveMode.Read)
                    ?? throw new FileLoadException("打开压缩包失败");
                using var entryStream = (zipArchive.GetEntry(Path.Combine(SDKZipEntry, SDKFileName))?.Open())
                    ?? throw new FileNotFoundException("压缩包中找不到文件");
                using var destStream = new MemoryStream();
                await entryStream.CopyToAsync(destStream, cancelSource!.Token);
                return destStream.ToArray();
            }
        }
    }
}
