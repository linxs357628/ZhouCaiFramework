using System.Drawing;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ZhouCaiFramework.Common
{
    public static class StringExtensions
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate bool SendClipboardTypedef(string result);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private delegate IntPtr RecvClipboardTypedef();

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private delegate void ClearClipboardTypedef();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libname);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        public static bool IsNullOrEmpty(this string sender)
        {
            return string.IsNullOrEmpty(sender);
        }

        public static string GetDirectoryCombine(this string fileName, string directory = null)
        {
            if (directory != null)
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), directory);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), directory, fileName);
            }

            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
        }

        public static bool SaveToFile(this string sender, string filePath, FileMode mode)
        {
            using MemoryStream msStream = new MemoryStream(Encoding.GetEncoding(Encoding.UTF8.WebName).GetBytes(sender));
            return msStream.SaveToFile(filePath, mode);
        }

        public static bool SaveToFile(this string sender, string filePath, FileMode mode, Encoding encoding = null)
        {
            byte[] buffer = ((encoding == null) ? Encoding.Default.GetBytes(sender) : encoding.GetBytes(sender));
            using MemoryStream msStream = new MemoryStream(buffer);
            return msStream.SaveToFile(filePath, mode);
        }

        public static byte[] DownloadPicToBytes(this string sender)
        {
            try
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadData(sender);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool DownloadPic(this string sender, string filePath)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] buffer = webClient.DownloadData(sender);
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    Image image = Image.FromStream(stream);
                    image.Save(filePath);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DownloadNetFileToLocal(this string sender, string filePath)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(sender);
                httpWebRequest.Timeout = 10000;
                WebResponse response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    stream.SaveToFile(filePath, FileMode.Create, 2048);
                }

                response.Close();
                response.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetFileToString(this string path, Encoding encoding = null)
        {
            using StreamReader streamReader = new StreamReader(path, encoding ?? Encoding.Default);
            return streamReader.ReadToEnd();
        }

        public static bool SaveToClipboard(this string sender)
        {
            bool result = true;
            IntPtr zero = IntPtr.Zero;
            zero = LoadLibrary("ADIWin32Helps.dll");
            if (zero == IntPtr.Zero)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to load library (ErrorCode: {lastWin32Error})");
            }

            IntPtr procAddress = GetProcAddress(zero, "SendClipboard");
            if (procAddress != IntPtr.Zero && Marshal.GetDelegateForFunctionPointer(procAddress, typeof(SendClipboardTypedef)) is SendClipboardTypedef sendClipboardTypedef)
            {
                result = sendClipboardTypedef(sender);
            }

            FreeLibrary(zero);
            return result;
        }

        public static string GetRecvClipboard()
        {
            string result = string.Empty;
            IntPtr zero = IntPtr.Zero;
            zero = LoadLibrary("ADIWin32Helps.dll");
            if (zero == IntPtr.Zero)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to load library (ErrorCode: {lastWin32Error})");
            }

            IntPtr procAddress = GetProcAddress(zero, "RecvClipboard");
            if (procAddress != IntPtr.Zero)
            {
                RecvClipboardTypedef recvClipboardTypedef = Marshal.GetDelegateForFunctionPointer(procAddress, typeof(RecvClipboardTypedef)) as RecvClipboardTypedef;
                try
                {
                    if (recvClipboardTypedef != null)
                    {
                        result = Marshal.PtrToStringAnsi(recvClipboardTypedef());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

            FreeLibrary(zero);
            return result;
        }

        public static void ClearClipboard()
        {
            IntPtr zero = IntPtr.Zero;
            zero = LoadLibrary("ADIWin32Helps.dll");
            if (zero == IntPtr.Zero)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to load library (ErrorCode: {lastWin32Error})");
            }

            IntPtr procAddress = GetProcAddress(zero, "ClealClipboard");
            if (procAddress != IntPtr.Zero)
            {
                ClearClipboardTypedef clearClipboardTypedef = Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ClearClipboardTypedef)) as ClearClipboardTypedef;
                try
                {
                    clearClipboardTypedef?.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

            FreeLibrary(zero);
        }

        public static Uri ToUri(this string urlResult)
        {
            return urlResult.ToUri(UriKind.RelativeOrAbsolute, null);
        }

        public static Uri ToUri(this string urlResult, UriKind uk, Uri defaultValue)
        {
            if (!string.IsNullOrEmpty(urlResult) && Uri.TryCreate(urlResult, uk, out Uri result))
            {
                return result;
            }

            return defaultValue;
        }

        public static IPAddress GetHostIPAddresses(this Uri uri)
        {
            if (uri == null)
            {
                return null;
            }

            IPAddress[] hostAddresses = Dns.GetHostAddresses(uri.Host);
            return (hostAddresses == null || hostAddresses.Length == 0) ? null : hostAddresses[0];
        }

        public static DateTime ToDateTimeFormat(this string st, string format)
        {
            try
            {
                return DateTime.ParseExact(st, format, CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GetTime(this string timeStamp)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long ticks = long.Parse(timeStamp + "0000000");
            TimeSpan value = new TimeSpan(ticks);
            return dateTime.Add(value);
        }

        public static string TryIndexOf(this string t, string flag)
        {
            return t.TryIndexOf(0, flag, refBack: false);
        }

        public static string TryIndexOf(this string t, int startIndex, string flag, bool refBack)
        {
            int num = t.IndexOf(flag);
            if (num > -1 && num != 0)
            {
                return t.Substring(startIndex, num);
            }

            if (refBack)
            {
                return t;
            }

            return "";
        }
    }
}