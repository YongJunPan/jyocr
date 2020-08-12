using System;
using System.IO;

namespace jyocr.Unit
{
    public class Base64Helper
    {
        /// <summary>
        /// 获取文件 base64 
        /// </summary>
        /// <param name="文件路径"></param>
        /// <returns></returns>
        public static string getFileBase64(string fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }
    }
}
