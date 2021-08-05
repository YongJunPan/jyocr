using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace jyocr.Unit
{
    class OCROffline
    {
        [DllImport("PaddleOCRExport.dll", EntryPoint = "PaddleOCRText", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern string PaddleOCRText(string base64_img);

        public static string OCROffile(string filePath, Image img = null)
        {
            string base64 = img == null ? Base64Helper.getFileBase64(filePath) : Base64Helper.getFileBase64("", Base64Helper.ImgToBytes(img));
            string returnStr = PaddleOCRText(base64);
            returnStr = Encoding.UTF8.GetString(Encoding.Default.GetBytes(returnStr));
            return returnStr;
        }
    }
}
