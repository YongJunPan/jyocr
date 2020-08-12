using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using jyocr.Unit;
using jyocr.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using CutPic;

namespace jyocr
{
    public partial class Form1 : Form
    {

        CutPic cutter = null;


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = generalBasic(textBox2.Text);
        }

        #region 通用文字识别
        public static string generalBasic(string filePath)
        {
            string returnStr = "";
            string token = "24.f4dda21cd3aed8bfb3c19a911abf75f6.2592000.1599808176.282335-21952800";
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = Base64Helper.getFileBase64(filePath);
            string str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            TreeObejct rs = JsonConvert.DeserializeObject<TreeObejct>(result);
            foreach (WordList ww in rs.words_result)
            {
                // Console.WriteLine(ww.words);
                returnStr += ww.words + "\r\n";
            }
            return returnStr;
        }
        #endregion

        #region 浏览文件路径按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:\\";//初始加载路径为C盘；
            openFileDialog1.Filter = "图片文件 (*.jpg,*.jpeg,*.png,*.bmp)|*.jgp;*.jpeg;*.png;*.bmp;"; //设置多文件格式
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }
        #endregion

        #region 用鼠标将某项拖动到该工作区时
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            textBox2.Text = path;
        }
        #endregion

        #region 拖动结束
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion


        protected void ShowCutPic()
        {
            Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g = Graphics.FromImage(CatchBmp);
            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));

            cutter = new CutPic();

            // 创建截图窗体
            // cutter = new Cutter();
            cutter.Image = CatchBmp;
            cutter.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowCutPic();
        }
    }
}
