using System;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json;
using jyocr.Unit;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace jyocr
{
    public partial class FormMain : Form
    {

        CutPic cutter = null;

        #region 窗口四边透明阴影
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;
        }
        #endregion

        public FormMain()
        {
            m_aeroEnabled = false;
            InitializeComponent();
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

            return returnStr;
        }
        #endregion

        #region 浏览文件路径按钮
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 (*.jpg,*.jpeg,*.png,*.bmp)|*.jgp;*.jpeg;*.png;*.bmp;"; //设置多文件格式
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RichTextBox_Value.Text = generalBasic(openFileDialog1.FileName);
            }
        }
        #endregion

        #region 文件拖动到该工作区时
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            RichTextBox_Value.Text = generalBasic(path);
        }
        #endregion

        #region 文件拖动结束
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                //RichTextBox_Value.Text = "";
                //RichTextBox_Value.Text = generalBasic(path);
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
                RichTextBox_Value.Text = generalBasic("", img);
                this.Visible = true;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            RichTextBox_Value.SelectionIndent = 40;
            RichTextBox_Value.SelectionHangingIndent = -35;
            //RichTextBox_Value.SelectionRightIndent = 0;

            RichTextBox_Value.AllowDrop = true;
            RichTextBox_Value.DragEnter += new DragEventHandler(FormMain_DragEnter);
            RichTextBox_Value.DragDrop += new DragEventHandler(FormMain_DragDrop);
        }
    }
}
