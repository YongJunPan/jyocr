using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace jyocr.Unit
{
    class HotKey
    {
        [Flags]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        [DllImport("user32.dll ", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll ", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        public static void SetHotkey(IntPtr hWnd, string text, string text2, string value, int flag)
        {
            var array = (value + "+").Split('+');
            if (array.Length == 3)
            {
                text = array[0];
                text2 = array[1];
            }
            if (array.Length == 2)
            {
                text = "None";
                text2 = value;
            }
            var array2 = new[]
            {
                text,
                text2
            };
            if (!RegisterHotKey(hWnd, flag, (KeyModifiers)Enum.Parse(typeof(KeyModifiers), array2[0].Trim()), (Keys)Enum.Parse(typeof(Keys), array2[1].Trim())))
            {
                MessageBox.Show("快捷键冲突，请更换！", "错误");
            }
            RegisterHotKey(hWnd, flag, (KeyModifiers)Enum.Parse(typeof(KeyModifiers), array2[0].Trim()), (Keys)Enum.Parse(typeof(Keys), array2[1].Trim()));
        }
    }
}
