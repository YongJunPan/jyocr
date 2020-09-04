namespace jyocr
{
    partial class FmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.ButtonFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ButtonCutPic = new System.Windows.Forms.Button();
            this.RichTextBoxValue = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonCopy = new System.Windows.Forms.Button();
            this.ButtonPart = new System.Windows.Forms.Button();
            this.ButtonSet = new System.Windows.Forms.Button();
            this.ButtonTop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelWordCount = new System.Windows.Forms.Label();
            this.MenuPart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.自动分段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.段落拆分ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.段落合并ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonFile
            // 
            this.ButtonFile.BackColor = System.Drawing.Color.Transparent;
            this.ButtonFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonFile.BackgroundImage")));
            this.ButtonFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonFile.FlatAppearance.BorderSize = 0;
            this.ButtonFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFile.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonFile.Location = new System.Drawing.Point(2, 4);
            this.ButtonFile.Name = "ButtonFile";
            this.ButtonFile.Size = new System.Drawing.Size(25, 25);
            this.ButtonFile.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ButtonFile, "浏览图片");
            this.ButtonFile.UseVisualStyleBackColor = false;
            this.ButtonFile.Click += new System.EventHandler(this.ButtonFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // ButtonCutPic
            // 
            this.ButtonCutPic.BackColor = System.Drawing.Color.Transparent;
            this.ButtonCutPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonCutPic.BackgroundImage")));
            this.ButtonCutPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonCutPic.FlatAppearance.BorderSize = 0;
            this.ButtonCutPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCutPic.Location = new System.Drawing.Point(30, 4);
            this.ButtonCutPic.Name = "ButtonCutPic";
            this.ButtonCutPic.Size = new System.Drawing.Size(25, 25);
            this.ButtonCutPic.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ButtonCutPic, "截图识别");
            this.ButtonCutPic.UseVisualStyleBackColor = false;
            this.ButtonCutPic.Click += new System.EventHandler(this.ButtonCutPic_Click);
            // 
            // RichTextBoxValue
            // 
            this.RichTextBoxValue.AcceptsTab = true;
            this.RichTextBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextBoxValue.Location = new System.Drawing.Point(0, 37);
            this.RichTextBoxValue.Name = "RichTextBoxValue";
            this.RichTextBoxValue.Size = new System.Drawing.Size(450, 300);
            this.RichTextBoxValue.TabIndex = 1;
            this.RichTextBoxValue.Text = "";
            this.RichTextBoxValue.TextChanged += new System.EventHandler(this.RichTextBoxValue_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 1);
            this.panel1.TabIndex = 4;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDelete.BackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDelete.BackgroundImage")));
            this.ButtonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonDelete.FlatAppearance.BorderSize = 0;
            this.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonDelete.Location = new System.Drawing.Point(395, 348);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(25, 25);
            this.ButtonDelete.TabIndex = 6;
            this.toolTip1.SetToolTip(this.ButtonDelete, "清空");
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonCopy
            // 
            this.ButtonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCopy.BackColor = System.Drawing.Color.Transparent;
            this.ButtonCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonCopy.BackgroundImage")));
            this.ButtonCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonCopy.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonCopy.FlatAppearance.BorderSize = 0;
            this.ButtonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCopy.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonCopy.Location = new System.Drawing.Point(425, 348);
            this.ButtonCopy.Name = "ButtonCopy";
            this.ButtonCopy.Size = new System.Drawing.Size(25, 25);
            this.ButtonCopy.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ButtonCopy, "复制");
            this.ButtonCopy.UseVisualStyleBackColor = false;
            this.ButtonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // ButtonPart
            // 
            this.ButtonPart.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonPart.BackgroundImage")));
            this.ButtonPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonPart.FlatAppearance.BorderSize = 0;
            this.ButtonPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPart.Location = new System.Drawing.Point(60, 4);
            this.ButtonPart.Name = "ButtonPart";
            this.ButtonPart.Size = new System.Drawing.Size(25, 25);
            this.ButtonPart.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ButtonPart, "自动分段");
            this.ButtonPart.UseVisualStyleBackColor = false;
            this.ButtonPart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonPart_MouseDown);
            // 
            // ButtonSet
            // 
            this.ButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSet.BackColor = System.Drawing.Color.Transparent;
            this.ButtonSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonSet.BackgroundImage")));
            this.ButtonSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonSet.FlatAppearance.BorderSize = 0;
            this.ButtonSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSet.Location = new System.Drawing.Point(425, 4);
            this.ButtonSet.Name = "ButtonSet";
            this.ButtonSet.Size = new System.Drawing.Size(25, 25);
            this.ButtonSet.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ButtonSet, "设置");
            this.ButtonSet.UseVisualStyleBackColor = false;
            this.ButtonSet.Click += new System.EventHandler(this.ButtonSet_Click);
            // 
            // ButtonTop
            // 
            this.ButtonTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTop.BackColor = System.Drawing.Color.Transparent;
            this.ButtonTop.BackgroundImage = global::jyocr.Properties.Resources.置顶;
            this.ButtonTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonTop.FlatAppearance.BorderSize = 0;
            this.ButtonTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTop.Location = new System.Drawing.Point(400, 4);
            this.ButtonTop.Name = "ButtonTop";
            this.ButtonTop.Size = new System.Drawing.Size(25, 25);
            this.ButtonTop.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ButtonTop, "置顶");
            this.ButtonTop.UseVisualStyleBackColor = false;
            this.ButtonTop.Click += new System.EventHandler(this.ButtonTop_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(2, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 1);
            this.panel2.TabIndex = 4;
            // 
            // LabelWordCount
            // 
            this.LabelWordCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelWordCount.AutoSize = true;
            this.LabelWordCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelWordCount.Location = new System.Drawing.Point(3, 353);
            this.LabelWordCount.Name = "LabelWordCount";
            this.LabelWordCount.Size = new System.Drawing.Size(51, 17);
            this.LabelWordCount.TabIndex = 5;
            this.LabelWordCount.Text = "字数：0";
            // 
            // MenuPart
            // 
            this.MenuPart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动分段ToolStripMenuItem,
            this.段落拆分ToolStripMenuItem,
            this.段落合并ToolStripMenuItem});
            this.MenuPart.Name = "MenuPart";
            this.MenuPart.Size = new System.Drawing.Size(129, 70);
            // 
            // 自动分段ToolStripMenuItem
            // 
            this.自动分段ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("自动分段ToolStripMenuItem.Image")));
            this.自动分段ToolStripMenuItem.Name = "自动分段ToolStripMenuItem";
            this.自动分段ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.自动分段ToolStripMenuItem.Text = "自动分段";
            this.自动分段ToolStripMenuItem.Click += new System.EventHandler(this.自动分段ToolStripMenuItem_Click);
            // 
            // 段落拆分ToolStripMenuItem
            // 
            this.段落拆分ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("段落拆分ToolStripMenuItem.Image")));
            this.段落拆分ToolStripMenuItem.Name = "段落拆分ToolStripMenuItem";
            this.段落拆分ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.段落拆分ToolStripMenuItem.Text = "段落拆分";
            this.段落拆分ToolStripMenuItem.Click += new System.EventHandler(this.段落拆分ToolStripMenuItem_Click);
            // 
            // 段落合并ToolStripMenuItem
            // 
            this.段落合并ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("段落合并ToolStripMenuItem.Image")));
            this.段落合并ToolStripMenuItem.Name = "段落合并ToolStripMenuItem";
            this.段落合并ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.段落合并ToolStripMenuItem.Text = "段落合并";
            this.段落合并ToolStripMenuItem.Click += new System.EventHandler(this.段落合并ToolStripMenuItem_Click);
            // 
            // FmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 376);
            this.Controls.Add(this.LabelWordCount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RichTextBoxValue);
            this.Controls.Add(this.ButtonTop);
            this.Controls.Add(this.ButtonSet);
            this.Controls.Add(this.ButtonPart);
            this.Controls.Add(this.ButtonCutPic);
            this.Controls.Add(this.ButtonCopy);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JYOCR";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FmMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.MenuPart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ButtonCutPic;
        private System.Windows.Forms.RichTextBox RichTextBoxValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelWordCount;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonCopy;
        private System.Windows.Forms.Button ButtonPart;
        private System.Windows.Forms.ContextMenuStrip MenuPart;
        private System.Windows.Forms.ToolStripMenuItem 自动分段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 段落拆分ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 段落合并ToolStripMenuItem;
        private System.Windows.Forms.Button ButtonSet;
        private System.Windows.Forms.Button ButtonTop;
    }
}

