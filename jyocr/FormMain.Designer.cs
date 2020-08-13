namespace jyocr
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Button_File = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button_CutPic = new System.Windows.Forms.Button();
            this.RichTextBox_Value = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Button_File
            // 
            this.Button_File.BackColor = System.Drawing.Color.Transparent;
            this.Button_File.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_File.BackgroundImage")));
            this.Button_File.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_File.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_File.FlatAppearance.BorderSize = 0;
            this.Button_File.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_File.ForeColor = System.Drawing.SystemColors.Control;
            this.Button_File.Location = new System.Drawing.Point(2, 2);
            this.Button_File.Name = "Button_File";
            this.Button_File.Size = new System.Drawing.Size(25, 25);
            this.Button_File.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Button_File, "浏览图片");
            this.Button_File.UseVisualStyleBackColor = false;
            this.Button_File.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // Button_CutPic
            // 
            this.Button_CutPic.BackColor = System.Drawing.Color.Transparent;
            this.Button_CutPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_CutPic.BackgroundImage")));
            this.Button_CutPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_CutPic.FlatAppearance.BorderSize = 0;
            this.Button_CutPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CutPic.Location = new System.Drawing.Point(30, 2);
            this.Button_CutPic.Name = "Button_CutPic";
            this.Button_CutPic.Size = new System.Drawing.Size(25, 25);
            this.Button_CutPic.TabIndex = 2;
            this.toolTip1.SetToolTip(this.Button_CutPic, "截图识别");
            this.Button_CutPic.UseVisualStyleBackColor = false;
            this.Button_CutPic.Click += new System.EventHandler(this.button3_Click);
            // 
            // RichTextBox_Value
            // 
            this.RichTextBox_Value.AcceptsTab = true;
            this.RichTextBox_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_Value.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextBox_Value.Location = new System.Drawing.Point(0, 35);
            this.RichTextBox_Value.Name = "RichTextBox_Value";
            this.RichTextBox_Value.Size = new System.Drawing.Size(450, 320);
            this.RichTextBox_Value.TabIndex = 3;
            this.RichTextBox_Value.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 1);
            this.panel1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RichTextBox_Value);
            this.Controls.Add(this.Button_CutPic);
            this.Controls.Add(this.Button_File);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JYOCR";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_File;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Button_CutPic;
        private System.Windows.Forms.RichTextBox RichTextBox_Value;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

