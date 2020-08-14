using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace jyocr
{
    public partial class FmCutPic : Form
    {
        private Point m_ptStart; //起始点位置
        private Image _Image;

        // 要裁剪的图像
        [Description("要裁剪的图像"), Category("Customs")]
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == this._Image) return;
                _Image = value;
            }
        }

        private Color _MaskColor = Color.FromArgb(50, 0, 0, 0);

        // 遮罩颜色
        [Description("遮罩颜色"), Category("Customs")]
        public Color MaskColor
        {
            get { return _MaskColor; }
            set
            {
                if (_MaskColor == value) return;
                _MaskColor = value;
                if (this._Image != null) this.Invalidate();
            }
        }

        // 获取或设置悬着区域
        private Rectangle _SelectedRectangle;

        public FmCutPic()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  

            InitializeComponent();
        }

        private void CutPic_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._Image == null)
            {
                return; //Image属性null或者已经锁定选择 直接返回
            }
            m_ptStart = e.Location; // 获取鼠标起始点位置
        }

        private void CutPic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (_Image != null)
            {
                g.DrawImage(this._Image, 0, 0, this._Image.Width, this._Image.Height);//原图
                using (SolidBrush sb = new SolidBrush(this._MaskColor))
                {
                    g.FillRectangle(sb, this.ClientRectangle);//遮罩
                }
                if (!this._SelectedRectangle.IsEmpty)
                {
                    this.DrawSelectedRectangle(g); //绘制选框
                }
            }
        }


        private void CutPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._Image == null)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                this._SelectedRectangle.X = e.Location.X > m_ptStart.X ? m_ptStart.X : e.Location.X;
                this._SelectedRectangle.Y = e.Location.Y > m_ptStart.Y ? m_ptStart.Y : e.Location.Y;
                this._SelectedRectangle.Width = Math.Abs(e.Location.X - m_ptStart.X);
                this._SelectedRectangle.Height = Math.Abs(e.Location.Y - m_ptStart.Y);
                this.Invalidate();
            }
        }


        private void CutPic_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Clip = Rectangle.Empty;
            ToolsPanel.Visible = true;
            this.Invalidate();

            //复制图片到剪切板
            Rectangle cropArea = new Rectangle(_SelectedRectangle.X, _SelectedRectangle.Y, _SelectedRectangle.Width, _SelectedRectangle.Height);
            if (cropArea.Height > 0 && cropArea.Width > 0) // 宽度和高度必须大于零
            {
                Bitmap bmpImage = new Bitmap(this._Image);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                Clipboard.SetImage(bmpCrop);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region 绘制选框
        protected virtual void DrawSelectedRectangle(Graphics g)
        {
            g.DrawImage(this._Image, this._SelectedRectangle, this._SelectedRectangle, GraphicsUnit.Pixel);
            g.DrawRectangle(Pens.Cyan, this._SelectedRectangle.Left, this._SelectedRectangle.Top, this._SelectedRectangle.Width - 1, this._SelectedRectangle.Height - 1);

            string str = string.Format("X:{0} Y:{1} W:{2} H:{3}", this._SelectedRectangle.Left, this._SelectedRectangle.Top, this._SelectedRectangle.Width, this._SelectedRectangle.Height);
            Size szStr = g.MeasureString(str, this.Font).ToSize();
            Point ptStr = new Point(this._SelectedRectangle.Left, this._SelectedRectangle.Top - szStr.Height - 5);
            if (ptStr.Y < 0) ptStr.Y = this._SelectedRectangle.Top + 5;
            if (ptStr.X + szStr.Width > this.Width) ptStr.X = this.Width - szStr.Width;
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(125, 0, 0, 0)))
            {
                g.FillRectangle(sb, new Rectangle(ptStr, szStr));
                g.DrawString(str, this.Font, Brushes.White, ptStr);
            }
        }
        #endregion

        #region 鼠标右键取消截图
        private void CutPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region ESC 取消截图
        private void CutPic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
    }
}
