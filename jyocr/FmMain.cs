using System;
using System.Windows.Forms;
using jyocr.Unit;
using System.Drawing;
using System.Runtime.InteropServices;
using jyocr.Properties;

namespace jyocr
{
    public partial class FmMain : Form
    {

        FmCutPic cutter = null;

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
                case 0x0312:
                    if (m.WParam.ToInt32() == 200)
                    {
                        ButtonCutPic_Click(null, null);
                    }
                    if (m.WParam.ToInt32() == 201)
                    {
                        Notify_DoubleClick(null, null);
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

        public FmMain()
        {
            m_aeroEnabled = false;
            InitializeComponent();
        }

        #region 软件加载
        private void FormMain_Load(object sender, EventArgs e)
        {
            // RichTextBox 段落缩进
            RichTextBoxValue.SelectionIndent = 40;
            RichTextBoxValue.SelectionHangingIndent = -35;

            // RichTextBox 拖放事件绑定
            RichTextBoxValue.AllowDrop = true;
            RichTextBoxValue.DragEnter += new DragEventHandler(FormMain_DragEnter);
            RichTextBoxValue.DragDrop += new DragEventHandler(FormMain_DragDrop);

            // 读取 ini 配置
            IniHelper.IniLoad("Setting.ini");

            Setting.TextPlus = IniHelper.GetValue("常规", "识别后文本累加") == "" ? false : bool.Parse(IniHelper.GetValue("常规", "识别后文本累加"));
            Setting.TextCopy = IniHelper.GetValue("常规", "识别后自动复制") == "" ? false : bool.Parse(IniHelper.GetValue("常规", "识别后自动复制"));
            Setting.FormHide = IniHelper.GetValue("常规", "截图时隐藏窗体") == "" ? false : bool.Parse(IniHelper.GetValue("常规", "截图时隐藏窗体"));
            Setting.FormTray = IniHelper.GetValue("常规", "右下角显示托盘") == "" ? false : bool.Parse(IniHelper.GetValue("常规", "右下角显示托盘"));
            this.Notify.Visible = Setting.FormTray;
            Setting.SelfStart = IniHelper.GetValue("常规", "开机自启") == "" ? false : bool.Parse(IniHelper.GetValue("常规", "开机自启"));

            OCRHelper.ApiKey = IniHelper.GetValue("百度接口", "API Key");
            OCRHelper.SecretKey = IniHelper.GetValue("百度接口", "Secret Key");
            OCRHelper.AccessToken = IniHelper.GetValue("百度接口", "Access Token");
            OCRHelper.Accurate = IniHelper.GetValue("百度接口", "使用高精度接口") == "" ? false : bool.Parse(IniHelper.GetValue("百度接口", "使用高精度接口"));

            // 判断 token 是否过期
            OCRHelper.DateToken = IniHelper.GetValue("百度接口", "Date Token");
            TimeSpan day = OCRHelper.DateToken == "" ? TimeSpan.MaxValue : DateTime.Now - DateTime.Parse(OCRHelper.DateToken);
            if (day.Days >= 30 && OCRHelper.ApiKey != "" && OCRHelper.SecretKey != "")
            {
                try
                {
                    string token = OCRHelper.GetBaiduToken(OCRHelper.ApiKey, OCRHelper.SecretKey);
                    if (token.Contains("错误"))
                    {
                        MessageBox.Show(this, token, "错误");
                    }
                    else
                    {
                        OCRHelper.AccessToken = token;
                        IniHelper.SetValue("百度接口", "Access Token", token);
                        IniHelper.SetValue("百度接口", "Date Token", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "错误");
                }
            }

            Setting.TranItem = IniHelper.GetValue("翻译", "默认网址") == "" ? 0 : int.Parse(IniHelper.GetValue("翻译", "默认网址"));
            Setting.TranOption = IniHelper.GetValue("翻译", "翻译选项") == "" ? 0 : int.Parse(IniHelper.GetValue("翻译", "翻译选项"));

            // 注册热键
            Setting.HotkeyCut = IniHelper.GetValue("热键", "截图识别");
            if (Setting.HotkeyCut != "" && Setting.HotkeyCut != "请按下快捷键")
            {
                HotKey.SetHotkey(Handle, "None", "F4", Setting.HotkeyCut, 200);
            }
            Setting.HotkeyShow = IniHelper.GetValue("热键", "显示/隐藏");
            if (Setting.HotkeyShow != "" && Setting.HotkeyShow != "请按下快捷键")
            {
                HotKey.SetHotkey(Handle, "None", "F4", Setting.HotkeyShow, 201);
            }
        }
        #endregion

        #region 软件关闭
        // 关闭前判断
        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing && Setting.FormTray)
            {
                // 取消"关闭窗口"事件
                // 只有 Form_Closing 事件中 e.Cancel可以用
                // Form_Closed 事件时窗口已关了，Cancel没用了
                // Form_Closing 是窗口即将关闭时询问你是不是真的关闭才有 Cancel 事件
                e.Cancel = true; // 取消关闭窗体 

                //使关闭时窗口向右下角缩小的效果
                this.WindowState = FormWindowState.Minimized;
                this.Notify.Visible = true;
                this.Hide();
                return;
            }
        }

        private void FmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 卸载热键
            HotKey.UnregisterHotKey(Handle, 200);
        }
        #endregion

        #region 浏览文件识别
        private void ButtonFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 (*.jpg,*.jpeg,*.png,*.bmp)|*.jgp;*.jpeg;*.png;*.bmp;"; //设置多文件格式
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonPart.Text = "自动分段";
                RichTextBoxValue.Text = OCRHelper.BaiduBasic(openFileDialog1.FileName).Trim();
                if (Setting.TextCopy)
                    ButtonCopy_Click(null, null);
            }
        }
        #endregion

        #region 截图识别
        private void ButtonCutPic_Click(object sender, EventArgs e)
        {
            if(Setting.FormHide)
            {
                this.Visible = false; // 截图时隐藏本窗体
                System.Threading.Thread.Sleep(200); // 延时，避免把本窗体也截下来
            }
            ShowCutPic();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            Application.DoEvents(); // DoEvents()将强制处理消息队列中的所有消息
            try
            {
                if (Clipboard.ContainsImage())
                {
                    ButtonPart.Text = "自动分段";
                    Image img = Clipboard.GetImage();  // 获取剪切板图片
                    RichTextBoxValue.Text = OCRHelper.BaiduBasic("", img).Trim(); // 识别剪切板图片的文字
                    if (Setting.TextCopy)
                        ButtonCopy_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误");
            }
        }

        /// <summary>
        /// 截图功能
        /// </summary>
        protected void ShowCutPic()
        {
            // 通过Graphics的CopyFromScreen方法把全屏图片的拷贝到我们定义好的一个和屏幕大小相同的空白图片中，
            // 拷贝完成之后，CatchBmp就是全屏图片的拷贝了，然后指定为截图窗体背景图片就好了。
            // 新建一个和屏幕大小相同的图片
            //Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Size Si = ScreenHelper.DESKTOP; // 获取屏幕真实分辨率
            Bitmap CatchBmp = new Bitmap(Si.Width, Si.Height);

            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics gra = Graphics.FromImage(CatchBmp);

            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            gra.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Si.Width, Si.Height));

            // 创建截图窗体
            cutter = new FmCutPic();

            // 指示窗体的背景图片为屏幕图片
            //cutter.Image = CatchBmp;
            // 如果分辨率进行了缩放，图片相应需要缩放
            cutter.Image = ScreenHelper.ScaleX > 1 ? shrinkTo(CatchBmp, Screen.AllScreens[0].Bounds.Size, true) : CatchBmp;
            cutter.Cursor = Cursors.Cross;
            cutter.ShowDialog();
        }

        /// <summary>
        /// 按指定尺寸对图像pic进行非拉伸缩放
        /// </summary>
        public static Bitmap shrinkTo(Image pic, Size S, Boolean cutting)
        {
            //创建图像
            Bitmap tmp = new Bitmap(S.Width, S.Height);     //按指定大小创建位图

            //绘制
            Graphics g = Graphics.FromImage(tmp);           //从位图创建Graphics对象
            g.Clear(Color.FromArgb(0, 0, 0, 0));            //清空

            Boolean mode = (float)pic.Width / S.Width > (float)pic.Height / S.Height;   //zoom缩放
            if (cutting) mode = !mode;                      //裁切缩放

            //计算Zoom绘制区域             
            if (mode)
                S.Height = (int)((float)pic.Height * S.Width / pic.Width);
            else
                S.Width = (int)((float)pic.Width * S.Height / pic.Height);
            Point P = new Point((tmp.Width - S.Width) / 2, (tmp.Height - S.Height) / 2);

            g.DrawImage(pic, new Rectangle(P, S));

            return tmp;     //返回构建的新图像
        }
        #endregion

        #region 文件拖动识别
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

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                ButtonPart.Text = "自动分段";
                string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                RichTextBoxValue.Text = OCRHelper.BaiduBasic(path).Trim();
                if (Setting.TextCopy)
                    ButtonCopy_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误");
            }
        }
        #endregion

        #region 复制、清空按钮
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            RichTextBoxValue.Text = "";
            OCRHelper.split_txt = "";
            OCRHelper.typeset_txt = "";
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, RichTextBoxValue.Text);
        }
        #endregion

        #region 段落按钮菜单功能
        private void ButtonPart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MenuPart.Show((Button)sender, new Point(ButtonPart.Left - ButtonPart.Width + 20, ButtonPart.Top + ButtonPart.Height));
            }
        }
        private void 自动分段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.Text = "自动分段";
            RichTextBoxValue.Text = OCRHelper.typeset_txt;
        }

        private void 段落拆分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.Text = "段落拆分";
            RichTextBoxValue.Text = OCRHelper.split_txt;
        }

        private void 段落合并ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonPart.Text = "段落合并";
            RichTextBoxValue.Text = RichTextBoxValue.Text.Replace("\n", "").Replace("\r", "");
        }
        #endregion

        private void RichTextBoxValue_TextChanged(object sender, EventArgs e)
        {
            LabelWordCount.Text = "字符数：" + RichTextBoxValue.Text.Trim().Length.ToString();
        }

        #region 设置按钮
        private void ButtonSet_Click(object sender, EventArgs e)
        {
            Form frm = new FmSetting();
            frm.ShowDialog();

            // 卸载热键重新注册
            if (Setting.HotkeyCut != "" && Setting.HotkeyCut != "请按下快捷键")
            {
                HotKey.UnregisterHotKey(Handle, 200);
                HotKey.SetHotkey(Handle, "None", "F4", Setting.HotkeyCut, 200);
            }
            if (Setting.HotkeyShow != "" && Setting.HotkeyShow != "请按下快捷键")
            {
                HotKey.UnregisterHotKey(Handle, 201);
                HotKey.SetHotkey(Handle, "None", "F4", Setting.HotkeyShow, 201);
            }
            this.Notify.Visible = Setting.FormTray;
        }
        #endregion

        #region 置顶按钮
        private void ButtonTop_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                ButtonTop.BackgroundImage = Resources.取消置顶;
                toolTip1.SetToolTip(ButtonTop, "取消置顶");
            }
            else
            {
                this.TopMost = true;
                ButtonTop.BackgroundImage = Resources.置顶;
                toolTip1.SetToolTip(ButtonTop, "置顶");
            }
        }
        #endregion

        #region 语言选项按钮
        private void ButtonLang_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (OCRHelper.Accurate)
                {
                    MenuLangAccurate.Show((Button)sender, new Point(ButtonLang.Left - ButtonLang.Width - 60, ButtonLang.Top + ButtonLang.Height));
                }
                else
                {
                    MenuLangBasic.Show((Button)sender, new Point(ButtonLang.Left - ButtonLang.Width - 60, ButtonLang.Top + ButtonLang.Height));
                }
            }
        }

        private void 中英混合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "中英混合";
            OCRHelper.Language = "CHN_ENG";
        }

        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "英文";
            OCRHelper.Language = "ENG";
        }

        private void 日语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "日语";
            OCRHelper.Language = "JAP";
        }

        private void 韩语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "韩语";
            OCRHelper.Language = "KOR";
        }

        private void 法语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "法语";
            OCRHelper.Language = "FRE";
        }

        private void 西班牙语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "西班牙语";
            OCRHelper.Language = "SPA";
        }

        private void 葡萄牙语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "葡萄牙语";
            OCRHelper.Language = "POR";
        }

        private void 德语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "德语";
            OCRHelper.Language = "GER";
        }

        private void 意大利语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "意大利语";
            OCRHelper.Language = "ITA";
        }

        private void 俄语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "俄语";
            OCRHelper.Language = "RUS";
        }

        private void 丹麦语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "丹麦语";
            OCRHelper.Language = "DAN";
        }

        private void 荷兰语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "荷兰语";
            OCRHelper.Language = "DUT";
        }

        private void 马来语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "马来语";
            OCRHelper.Language = "MAL";
        }

        private void 瑞典语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "瑞典语";
            OCRHelper.Language = "SWE";
        }

        private void 印尼语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "印尼语";
            OCRHelper.Language = "IND";
        }

        private void 波兰语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "波兰语";
            OCRHelper.Language = "POL";
        }

        private void 罗马尼亚语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "罗马尼亚";
            OCRHelper.Language = "ROM";
        }

        private void 土耳其语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "土耳其语";
            OCRHelper.Language = "TUR";
        }

        private void 希腊语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "希腊语";
            OCRHelper.Language = "GRE";
        }

        private void 匈牙利语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "匈牙利语";
            OCRHelper.Language = "HUN";
        }

        private void 自动检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonLang.Text = "自动检测";
            OCRHelper.Language = "auto_detect";
        }
        #endregion

        #region 托盘
        private void Notify_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "你确定要退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Notify.Visible = false;
                this.Close();
                this.Dispose();
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion

        private void ButtonTranslate_Click(object sender, EventArgs e)
        {
            if (RichTextBoxValue.Text != "")
                Translate.goTranslate(RichTextBoxValue.Text);
        }
    }
}
