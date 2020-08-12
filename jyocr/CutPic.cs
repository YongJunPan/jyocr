using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyocr
{
    public partial class CutPic : Form
    {
        private Point m_ptStart;        //起始点位置
        private Point m_ptCurrent;      //当前鼠标位置
        private Point m_ptTempForMove;  //移动选框的时候临时用
        private Rectangle m_rectClip;   //限定鼠标活动的区域
        private Rectangle[] m_rectDots = new Rectangle[8];  //八个控制点
        protected bool m_bMoving;
        protected bool m_bChangeWidth;
        protected bool m_bChangeHeight;
        protected bool m_bMouseHover;
        private bool _IsDrawed; /// 获取当前是否已经选择区域
        private Image _Image;
        ///
        /// 要裁剪的图像
        ///
        [Description("要裁剪的图像"), Category("Customs")]
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == this._Image) return;
                _Image = value;
                //   this.Clear();
            }
        }
        private Color _MaskColor = Color.FromArgb(125, 0, 0, 0);
        ///
        /// 遮罩颜色
        ///
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
        private Rectangle _SelectedRectangle;/// 获取或设置悬着区域

        public CutPic()
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
                return;//Image属性null或者已经锁定选择 直接返回
            }
            m_ptStart = e.Location;
            m_bChangeHeight = true;
            m_bChangeWidth = true;

            //判断若不在限定范围内操作 返回
            m_rectClip = this.DisplayRectangle;
            Size sz = this.Size;
            sz = this.Size;
            m_rectClip.Intersect(new Rectangle(Point.Empty, sz));
            m_rectClip.Width++; m_rectClip.Height++;
            Cursor.Clip = RectangleToScreen(m_rectClip);


            if (ToolsPanel.Visible == true)
            {
                ToolsPanel.Visible = false;
            }
            //如果 已经选择区域 若鼠标点下 判断是否在控制顶点上
            if (this._IsDrawed)
            {
                this._IsDrawed = false; //默认表示 要更改选取设置 清楚IsDrawed属性
                if (m_rectDots[0].Contains(e.Location))
                {
                    m_ptStart.X = this._SelectedRectangle.Right;
                    m_ptStart.Y = this._SelectedRectangle.Bottom;
                }
                else if (m_rectDots[1].Contains(e.Location))
                {
                    m_ptStart.Y = this._SelectedRectangle.Bottom;
                    m_bChangeWidth = false;
                }
                else if (m_rectDots[2].Contains(e.Location))
                {
                    m_ptStart.X = this._SelectedRectangle.X;
                    m_ptStart.Y = this._SelectedRectangle.Bottom;
                }
                else if (m_rectDots[3].Contains(e.Location))
                {
                    m_ptStart.X = this._SelectedRectangle.Right;
                    m_bChangeHeight = false;
                }
                else if (m_rectDots[4].Contains(e.Location))
                {
                    m_ptStart.X = this._SelectedRectangle.X;
                    m_bChangeHeight = false;
                }
                else if (m_rectDots[5].Contains(e.Location))
                {
                    m_ptStart.X = this._SelectedRectangle.Right;
                    m_ptStart.Y = this._SelectedRectangle.Y;
                }
                else if (m_rectDots[6].Contains(e.Location))
                {
                    m_ptStart.Y = this._SelectedRectangle.Y;
                    m_bChangeWidth = false;
                }
                else if (m_rectDots[7].Contains(e.Location))
                {
                    m_ptStart = this._SelectedRectangle.Location;
                }
                else if (this._SelectedRectangle.Contains(e.Location))
                {
                    m_bMoving = true;
                    m_bChangeWidth = false;
                    m_bChangeHeight = false;
                }
                else { this._IsDrawed = true; }   //若以上条件不成立 表示不需要更改设置
            }
        }

        private void CutPic_MouseClick(object sender, MouseEventArgs e)
        {

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
                    this.DrawSelectedRectangle(g);//选框
            }
            SetPanleLocation();
        }

        private void CutPic_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                m_rectDots[i].Size = new Size(5, 5);
            }

            m_ptTempForMove = this.DisplayRectangle.Location;

        }

        private void CutPic_MouseMove(object sender, MouseEventArgs e)
        {
            m_ptCurrent = e.Location;
            if (this._Image == null)
            {
                return;
            }
            if (this._IsDrawed)
            {//如果已经绘制 移动过程中判断是否需要设置鼠标样式
                this.SetCursorStyle(e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {//否则可能表示在选择区域或重置大小
                if (m_bChangeWidth)
                {//是否允许选区宽度改变 如重置大小时候 拉动上边和下边中点时候
                    this._SelectedRectangle.X = e.Location.X > m_ptStart.X ? m_ptStart.X : e.Location.X;
                    this._SelectedRectangle.Width = Math.Abs(e.Location.X - m_ptStart.X);
                }
                if (m_bChangeHeight)
                {
                    this._SelectedRectangle.Y = e.Location.Y > m_ptStart.Y ? m_ptStart.Y : e.Location.Y;
                    this._SelectedRectangle.Height = Math.Abs(e.Location.Y - m_ptStart.Y);
                }
                if (m_bMoving)
                {//如果是移动选区 判断选区移动范围
                    int tempX = m_ptTempForMove.X + e.X - m_ptStart.X;
                    int tempY = m_ptTempForMove.Y + e.Y - m_ptStart.Y;

                    if (tempX < 0) tempX = 0;
                    if (tempY < 0) tempY = 0;
                    if (this._SelectedRectangle.Width + tempX >= m_rectClip.Width) tempX = m_rectClip.Width - this._SelectedRectangle.Width - 1;
                    if (this._SelectedRectangle.Height + tempY >= m_rectClip.Height) tempY = m_rectClip.Height - this._SelectedRectangle.Height - 1;

                    this._SelectedRectangle.X = tempX;
                    this._SelectedRectangle.Y = tempY;
                }
                this.Invalidate();
            }
            else if (!this._IsDrawed)
            {
                this.Invalidate();//否则 在需要绘制放大镜并且还没有选好区域同时 都重绘
            }
        }
        ///
        /// 判断鼠标当前位置显示样式
        ///
        /// 鼠标坐标
        protected virtual void SetCursorStyle(Point pt)
        {
            if (m_rectDots[0].Contains(pt) || m_rectDots[7].Contains(pt))
                this.Cursor = Cursors.SizeNWSE;
            else if (m_rectDots[1].Contains(pt) || m_rectDots[6].Contains(pt))
                this.Cursor = Cursors.SizeNS;
            else if (m_rectDots[2].Contains(pt) || m_rectDots[5].Contains(pt))
                this.Cursor = Cursors.SizeNESW;
            else if (m_rectDots[3].Contains(pt) || m_rectDots[4].Contains(pt))
                this.Cursor = Cursors.SizeWE;
            else if (this._SelectedRectangle.Contains(pt))
                this.Cursor = Cursors.SizeAll;
            else
                this.Cursor = Cursors.Default;
        }

        private void CutPic_MouseUp(object sender, MouseEventArgs e)
        {
            this._IsDrawed = !this._SelectedRectangle.IsEmpty;
            m_ptTempForMove = this._SelectedRectangle.Location;
            m_bMoving = false;
            m_bChangeWidth = false;
            m_bChangeHeight = false;
            Cursor.Clip = Rectangle.Empty;
            ToolsPanel.Visible = true;
            this.Invalidate();



        }

        public void SetPanleLocation()
        {
            ToolsPanel.Left = this._SelectedRectangle.Left + this._SelectedRectangle.Width - ToolsPanel.Width;
            ToolsPanel.Top = this._SelectedRectangle.Top + this._SelectedRectangle.Height + 5;
        }


        ///
        /// 绘制选框
        ///
        /// 绘图表面
        protected virtual void DrawSelectedRectangle(Graphics g)
        {
            m_rectDots[0].Y = m_rectDots[1].Y = m_rectDots[2].Y = this._SelectedRectangle.Y - 2;
            m_rectDots[5].Y = m_rectDots[6].Y = m_rectDots[7].Y = this._SelectedRectangle.Bottom - 2;
            m_rectDots[0].X = m_rectDots[3].X = m_rectDots[5].X = this._SelectedRectangle.X - 2;
            m_rectDots[2].X = m_rectDots[4].X = m_rectDots[7].X = this._SelectedRectangle.Right - 2;
            m_rectDots[3].Y = m_rectDots[4].Y = this._SelectedRectangle.Y + this._SelectedRectangle.Height / 2 - 2;
            m_rectDots[1].X = m_rectDots[6].X = this._SelectedRectangle.X + this._SelectedRectangle.Width / 2 - 2;

            g.DrawImage(this._Image, this._SelectedRectangle, this._SelectedRectangle, GraphicsUnit.Pixel);
            g.DrawRectangle(Pens.Cyan, this._SelectedRectangle.Left, this._SelectedRectangle.Top, this._SelectedRectangle.Width - 1, this._SelectedRectangle.Height - 1);
            foreach (Rectangle rect in m_rectDots)
                g.FillRectangle(Brushes.Yellow, rect);
            string str = string.Format("X:{0} Y:{1} W:{2} H:{3}",
                this._SelectedRectangle.Left, this._SelectedRectangle.Top, this._SelectedRectangle.Width, this._SelectedRectangle.Height);
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

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddhhmmss");
            saveFileDialog.Filter = "png|*.png|bmp|*.bmp|jpg|*.jpg|gif|*.gif";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                System.Drawing.Rectangle cropArea = new System.Drawing.Rectangle(_SelectedRectangle.X, _SelectedRectangle.Y, _SelectedRectangle.Width, _SelectedRectangle.Height);
                Bitmap bmpImage = new Bitmap(this._Image);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                bmpCrop.Save(saveFileDialog.FileName);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Focus();
            }
        }


        private void CutPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._SelectedRectangle.Contains(e.Location))
            {
                //复制图片到剪切板
                System.Drawing.Rectangle cropArea = new System.Drawing.Rectangle(_SelectedRectangle.X, _SelectedRectangle.Y, _SelectedRectangle.Width, _SelectedRectangle.Height);
                Bitmap bmpImage = new Bitmap(this._Image);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                Clipboard.SetImage(bmpCrop);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CutPic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
