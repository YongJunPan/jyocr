using System;
using System.Drawing;
using System.Drawing.Imaging;
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
        public static string getFileBase64(string fileName, byte[] inArray = null)
        {
            string baser64 = "";
            if (inArray == null)
            {
                FileStream filestream = new FileStream(fileName, FileMode.Open);
                byte[] arr = new byte[filestream.Length];
                filestream.Read(arr, 0, (int)filestream.Length);
                baser64 = Convert.ToBase64String(arr);
                filestream.Close(); 
            }
            else
            {
                baser64 = Convert.ToBase64String(inArray);
            }
            return baser64;
        }

        /// <summary>
        /// 图片转 byte
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImgToBytes(Image img)
        {
            byte[] result;
            try
            {
                var memoryStream = new MemoryStream();
                img.Save(memoryStream, ImageFormat.Jpeg);
                var array = new byte[memoryStream.Length];
                memoryStream.Position = 0L;
                memoryStream.Read(array, 0, (int)memoryStream.Length);
                memoryStream.Close();
                result = array;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
