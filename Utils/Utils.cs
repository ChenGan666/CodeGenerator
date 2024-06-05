using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ZNS.CodeGenerator.Utils
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
    {
        //public const string ASSEMBLY_VERSION = "2.5.0";

        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
        private static Regex RegexBrB = new Regex(@"(\r)", RegexOptions.IgnoreCase);
        private static Regex RegexBrC = new Regex(@"(\n)", RegexOptions.IgnoreCase);
        public static Regex RegexFont = new Regex(@"<font color=" + "\".*?\"" + @">([\s\S]+?)</font>", Utils.GetRegexCompiledOptions());

        private static readonly FileVersionInfo AssemblyFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        private static string TemplateCookieName = string.Format("templateskinname_{0}_{1}_{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);


        /// <summary>
        /// 得到正则编译参数设置
        /// </summary>
        /// <returns>参数设置</returns>
        public static RegexOptions GetRegexCompiledOptions()
        {
#if NET1
            return RegexOptions.Compiled;
#else
            return RegexOptions.None;
#endif
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>创建是否成功</returns>
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);
        /// <summary>
        /// 建立文件夹
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateDir(string name)
        {
            return Utils.MakeSureDirectoryPathExists(name);
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!Utils.StrIsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    string[] tmp = { strContent };
                    return tmp;
                }
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }
        /// <summary>
        /// 字段串是否为Null或为""(空)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StrIsNullOrEmpty(string str)
        {
            //#if NET1
            if (str == null || str.Trim() == "")
            {
                return true;
            }
            //#else
            //            if (string.IsNullOrEmpty(str))
            //            {
            //                return true;
            //            }
            //#endif

            return false;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];

            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }
        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object Expression)
        {
            return TypeParse.IsNumeric(Expression);
        }
        /// <summary>
        /// 算一个值到另一个值范围内的值
        /// </summary>
        public static float ValueBound(int tValue, int AMin, int AMax, int BMin, int BMax)
        {
            float reValue = 0;
            if (tValue > AMin && tValue < AMax)
            {
                float a = BMax - BMin;
                float b = (float.Parse(tValue.ToString()) - float.Parse(AMin.ToString())) / (float.Parse(AMax.ToString()) - float.Parse(AMin.ToString()));
                float c = a * b + BMin;

                reValue = c;
            }
            else if (tValue <= AMin)
            {
                reValue = BMin;
            }
            else if (tValue >= AMax)
            {
                reValue = BMax;
            }
            return reValue;
        }


        #region SQL语句处理
        /// <summary>
        /// 去除字符串中的最后一个分隔符
        /// </summary>
        public static string ReStrCheckPo(string cStr, string gP)
        {
            if (cStr.Trim() != "")
            {
                if (cStr.Substring(cStr.Length - 1, 1) == gP)
                {
                    cStr = cStr.Substring(0, cStr.Length - 1);
                }
            }
            return cStr;
        }
        /// <summary>
        /// 返回整理后的SQL数据集合,例子:1,2,3,4
        /// </summary>
        public static string ReSQLSetTxt(string SetTxt)
        {
            string tRe = "";
            if (SetTxt.IndexOf(",") > -1)
            {
                string[] tV = SetTxt.Split(new Char[] { ',' });
                if (tV.Length > 0)
                {
                    for (int i = 0; i < tV.Length; i++)
                    {
                        if (tV[i] != null)
                        {
                            if (tV[i].Trim() != "")
                            {
                                tRe += tV[i].Trim() + ",";
                            }
                        }
                    }
                }
            }
            if (tRe.Trim() != "")
            {
                tRe = ReStrCheckPo(tRe, ",");
            }
            else
            {
                tRe = SetTxt;
            }
            return tRe;
        }

        /// <summary>
        /// 返回整理后的SQL数据集合,例子:1,2,3,4
        /// </summary>
        /// <param name="SetTxt">原字符串</param>
        /// <param name="aStr">单字符前后增加字符</param>
        public static string ReSQLSetTxt(string SetTxt, string aStr)
        {
            string tRe = "";
            if (SetTxt.IndexOf(",") > -1)
            {
                string[] tV = SetTxt.Split(new Char[] { ',' });
                if (tV.Length > 0)
                {
                    for (int i = 0; i < tV.Length; i++)
                    {
                        if (tV[i] != null)
                        {
                            if (tV[i].Trim() != "")
                            {
                                tRe += aStr + tV[i].Trim() + aStr + ",";
                            }
                        }
                    }
                }
            }
            if (tRe.Trim() != "")
            {
                tRe = ReStrCheckPo(tRe, ",");
            }
            else
            {
                tRe = SetTxt;
            }
            return tRe;
        }

        /// <summary>
        /// 返回整理后的SQL数据集合,例子:1,2,3,4
        /// </summary>
        public static string ReSQLSetTxt(string SetTxt, string gP, string tP)
        {
            string tRe = "";
            if (SetTxt.IndexOf(",") > -1)
            {
                string[] tV = SetTxt.Split(gP.ToCharArray());
                if (tV.Length > 0)
                {
                    for (int i = 0; i < tV.Length; i++)
                    {
                        if (tV[i] != null)
                        {
                            if (tV[i].Trim() != "")
                            {
                                tRe += tV[i].Trim() + tP;
                            }
                        }
                    }
                }
            }
            if (tRe.Trim() != "")
            {
                tRe = ReStrCheckPo(tRe, tP);
            }
            return tRe;
        }
        /// <summary>
        /// 改正sql语句中的转义字符
        /// </summary>
        public static string mashSQL(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\'", "'");
                str2 = str;
            }
            return str2;
        }

        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        public static string ChkSQL(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("'", "''");
                str2 = str;
            }
            return str2;
        }
        #endregion

        #region Assembly 信息部分
        /// <summary>
        /// 获得Assembly版本号
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);
        }

        /// <summary>
        /// 获得Assembly产品名称
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return AssemblyFileVersion.ProductName;
        }

        /// <summary>
        /// 获得Assembly产品版权
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyCopyright()
        {
            return AssemblyFileVersion.LegalCopyright;
        }
        #endregion

        #region 时间处理
        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalSeconds < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalMinutes < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalMinutes;
        }

        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalHours < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalHours;
        }
        /// <summary>
        /// 当前时间加分钟
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string AdDeTime(int times)
        {
            string newtime = (DateTime.Now).AddMinutes(times).ToString();
            return newtime;

        }

        /// <summary>
        /// 计算两个时间差,并返回 x天/x小时/x分钟/x秒
        /// </summary>
        public static string SubtractTime(DateTime OneTime, DateTime TowTime)
        {
            TimeSpan span = OneTime.Subtract(TowTime);
            if (span.Days > 0)
            {
                return span.Days + "天";
            }
            else if (span.Hours > 0)
            {
                return span.Hours + "小时";
            }
            else if (span.Minutes > 0)
            {
                return span.Minutes + "分钟";
            }
            else if (span.Seconds > 0)
            {
                return span.Seconds + "秒";
            }
            else
            {
                return "3秒";
            }
        }
        #endregion

        #region 任意进制转换
        /// <summary>
        /// 任意进制转换
        /// </summary>
        /// <param name="baseChars">表示从0-N的字符序列</param>
        public static string BaseConverterToString(string baseChars, int value)
        {
            BaseConverter bc = new BaseConverter(baseChars.ToCharArray());
            return bc.ToString(value);
        }
        public class BaseConverter
        {
            protected List<char> _chars = new List<char>();
            protected Dictionary<char, int> _charmap = new Dictionary<char, int>();
            protected List<long> _preBitValue = new List<long>();

            /**/
            /// <summary>
            /// 得到进制指定权位的值
            /// </summary>
            /// <param name="pos">权位</param>
            /// <returns>权位的数值</returns>
            protected long GetPowerValue(int pos)
            {
                if (_preBitValue.Count < pos)
                {
                    for (int i = _preBitValue.Count; i <= pos; ++i)
                    {
                        _preBitValue.Add(Convert.ToInt64(Math.Pow(_chars.Count, i)));
                    }
                }

                return _preBitValue[pos];
            }

            /**/
            /// <summary>
            /// 构造一个指定进制和字符的转换器
            /// </summary>
            /// <param name="baseChars">表示从0-N的字符序列</param>
            public BaseConverter(char[] baseChars)
            {
                _chars.AddRange(baseChars);

                for (int i = 0; i < baseChars.Length; ++i)
                {
                    _charmap.Add(baseChars[i], i);
                }
            }

            /**/
            /// <summary>
            /// 把用指定进制和字符的字串, 解释成等值的十进制数值
            /// </summary>
            /// <param name="value">指定进制和字符的字串</param>
            /// <returns>等值的十进制数值</returns>
            public long ToNumber(string value)
            {
                char[] chars = value.ToCharArray();

                long ret = 0;
                for (int i = 0; i < chars.Length; ++i)
                {
                    ret += GetPowerValue(chars.Length - 1 - i) * _charmap[chars[i]];
                }

                return ret;
            }

            /**/
            /// <summary>
            /// 把当前十进制数值用指定的进制和字符表现出来
            /// </summary>
            /// <param name="value">十进制数值</param>
            /// <returns>表现出来的字串</returns>
            public string ToString(long value)
            {
                int power = _chars.Count;
                List<char> list = new List<char>();

                while (value > 0)
                {
                    int l = Convert.ToInt32(value % power);
                    value /= power;

                    list.Add(_chars[l]);
                }

                list.Reverse();

                return new string(list.ToArray());
            }
        }
        #endregion


        #region Excel操作
        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="strExcelFileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            //源的定义
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";

            //Sql语句
            //string strExcel = string.Format("select * from [{0}$]", strSheetName); 这是一种方法
            string strExcel = "select * from [sheet1$]";

            //定义存放的数据表
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                try
                {
                    conn.Open();
                    //适配到数据源
                    OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                    try
                    {
                        adapter.Fill(ds, strSheetName);
                    }
                    finally
                    {
                        adapter.Dispose();
                    }
                    dt = ds.Tables[strSheetName];
                }
                catch//使用XML方式读取
                {
                    ds.ReadXml(strExcelFileName);

                    dt = ds.Tables[strSheetName];
                }
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion

    }

    public class LockBitmap
    {
        Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // get total locked pixels count
                int PixelCount = Width * Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
                                             source.PixelFormat);

                // create byte array to copy pixel values
                int step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24) // For 24 bpp set Red, Green and Blue
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            // For 8 bpp set color value (Red, Green and Blue values are the same)
            {
                Pixels[i] = color.B;
            }
        }
    }
}
