using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNS.CodeGenerator.Utils
{
    public class FileHelper
    {
        public static string GetUtf8Content(string sourceFolder)
        {
            var content = File.ReadAllText(sourceFolder);
            if (GetType(sourceFolder) == "gb2312")
            {
                content = gb2312_utf8(File.ReadAllText(sourceFolder, System.Text.Encoding.GetEncoding("gb2312")));
            }

            return content;
        }

        public static void FileToUtf8(string sourceFolder, string destFolder)
        {
            File.WriteAllText(destFolder, GetUtf8Content(destFolder), System.Text.Encoding.GetEncoding("utf-8"));
        }

        public static string gb2312_utf8(string text)
        {
            //声明字符集
            System.Text.Encoding utf8, gb2312;
            //gb2312
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //utf8
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            byte[] gb;
            gb = gb2312.GetBytes(text);
            gb = System.Text.Encoding.Convert(gb2312, utf8, gb);
            //返回转换后的字符
            return utf8.GetString(gb);
        }

        public static string GetType(string name)
        {
            try
            {

                FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                System.Text.Encoding r = GetType(fs);
                fs.Close();
                return r.BodyName;
            }
            catch (Exception e)
            {
                Console.WriteLine(name);
                return "";
            }
        }

        public static System.Text.Encoding GetType(FileStream fs)
        {
            /*byte[] Unicode=new byte[]{0xFF,0xFE};  
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF};  
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            byte[] ss = r.ReadBytes(3);
            r.Close();
            //编码类型 Coding=编码类型.ASCII;   
            if (ss[0] >= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    return System.Text.Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    return System.Text.Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return System.Text.Encoding.Unicode;
                }
                else
                {
                    return System.Text.Encoding.Default;
                }
            }
            else
            {
                return System.Text.Encoding.Default;
            }
        }
    }
}
