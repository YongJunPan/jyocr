namespace jyocr
{
    partial class CutPic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.BackColor = System.Drawing.Color.Transparent;
            this.ToolsPanel.Location = new System.Drawing.Point(27, 142);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(200, 27);
            this.ToolsPanel.TabIndex = 2;
            this.ToolsPanel.Visible = false;
            // 
            // CutPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ToolsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CutPic";
            this.Text = "CutPic";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CutPic_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CutPic_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ToolsPanel;
    }
}