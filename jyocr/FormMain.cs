using System;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json;
using jyocr.Unit;
using jyocr.Models;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace jyocr
{
    public partial class FormMain : Form
    {

        CutPic cutter = null;

        public FormMain()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = generalBasic(textBox2.Text);
        }

        #region 通用文字识别
        public static string generalBasic(string filePath,Image img = null)
        {
            string base64 = "";
            string returnStr = "";
            string token = "24.f4dda21cd3aed8bfb3c19a911abf75f6.2592000.1599808176.282335-21952800";
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=" + token;

            if (img == null)
            {
                base64 = Base64Helper.getFileBase64(filePath); // 图片文件的 base64 编码
            }
            else
            {
                base64 = Base64Helper.getFileBase64("", Base64Helper.ImgToBytes(img)); // 剪切板图片的 base64 编码
            }

            string data = "image=" + HttpUtility.UrlEncode(base64);
            string result = HttpClient.Post(data, host);
            var jArray = JArray.Parse(((JObject)JsonConvert.DeserializeObject(result))["words_result"].ToString());
            returnStr = OCRHelper.checked_txt(jArray, 1, "words");

            //TreeObejct json = JsonConvert.DeserializeObject<TreeObejct>(result);
            //foreach (WordList word in json.words_result)
            //{
            //    returnStr += word.words + "\r\n";
            //}

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

        #region 文件拖动到该工作区时
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            textBox2.Text = path;
        }
        #endregion

        #region 文件拖动结束
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

            // 创建截图窗体
            cutter = new CutPic();
            cutter.Image = CatchBmp;
            cutter.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            System.Threading.Thread.Sleep(200);
            ShowCutPic();

            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                textBox1.Text = generalBasic("", img);
                this.Visible = true;
            }
            else
            {
                this.Visible = true;
            }
        }

    }
}
