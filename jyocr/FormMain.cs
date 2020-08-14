using System;
using System.Windows.Forms;
using jyocr.Unit;
using System.Drawing;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            // RichTextBox 段落缩进
            RichTextBoxValue.SelectionIndent = 40;
            RichTextBoxValue.SelectionHangingIndent = -35;

            // RichTextBox 拖放事件绑定
            RichTextBoxValue.AllowDrop = true;
            RichTextBoxValue.DragEnter += new DragEventHandler(FormMain_DragEnter);
            RichTextBoxValue.DragDrop += new DragEventHandler(FormMain_DragDrop);
        }

        #region 浏览文件按钮
        private void ButtonFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 (*.jpg,*.jpeg,*.png,*.bmp)|*.jgp;*.jpeg;*.png;*.bmp;"; //设置多文件格式
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonPart.BackgroundImage = 自动分段ToolStripMenuItem.Image;
                RichTextBoxValue.Text = OCRHelper.BaiduBasic(openFileDialog1.FileName);
            }
        }
        #endregion

        #region 截图识别按钮
        private void ButtonCutPic_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            System.Threading.Thread.Sleep(200);
            ShowCutPic();

            if (Clipboard.ContainsImage())
            {
                ButtonPart.BackgroundImage = 自动分段ToolStripMenuItem.Image;
                Image img = Clipboard.GetImage();
                RichTextBoxValue.Text = OCRHelper.BaiduBasic("", img);
                this.Visible = true;
            }
            else
            {
                this.Visible = true;
            }
        }
        #endregion

        #region 截图功能
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
        #endregion

        #region 文件拖动结束
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            ButtonPart.BackgroundImage = 自动分段ToolStripMenuItem.Image;
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            RichTextBoxValue.Text = OCRHelper.BaiduBasic(path);
        }
        #endregion

        #region 文件拖动到工作区时
        private void FormMain_DragEnter(object sender, DragEventArgs e)
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

        #region 复制、清空按钮
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            RichTextBoxValue.Text = "";
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, RichTextBoxValue.Text);
        }
        #endregion

        #region TextBox右键菜单功能
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, RichTextBoxValue.Text);
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, RichTextBoxValue.Text);
            RichTextBoxValue.Text = "";
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxValue.SelectAll();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxValue.Paste();
        }
        #endregion

        #region 段落按钮菜单功能
        private void 自动分段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.BackgroundImage = 自动分段ToolStripMenuItem.Image;
            RichTextBoxValue.Text = OCRHelper.typeset_txt;
        }

        private void 段落拆分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.BackgroundImage = 段落拆分ToolStripMenuItem.Image;
            RichTextBoxValue.Text = OCRHelper.split_txt;
        }

        private void 段落合并ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.BackgroundImage = 段落合并ToolStripMenuItem.Image;
            RichTextBoxValue.Text = RichTextBoxValue.Text.Replace("\n", "").Replace("\r", "");
        }

        private void ButtonPart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MenuPart.Show((Button)sender, new Point(ButtonPart.Left - ButtonPart.Width - 30, ButtonPart.Top + ButtonPart.Height));
            }
        }
        #endregion

        private void RichTextBoxValue_TextChanged(object sender, EventArgs e)
        {
            LabelWordCount.Text = "字数：" + RichTextBoxValue.Text.Length.ToString();
        }

        

    }
}
