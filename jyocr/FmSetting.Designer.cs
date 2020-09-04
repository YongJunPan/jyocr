namespace jyocr
{
    partial class FmSetting
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
            this.ListBoxMenu = new System.Windows.Forms.ListBox();
            this.TextBoxHotkey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxToken = new System.Windows.Forms.TextBox();
            this.TextBoxSecretKey = new System.Windows.Forms.TextBox();
            this.TextBoxApiKey = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonApiTest = new System.Windows.Forms.Button();
            this.ButtonAapply = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelBaidu = new System.Windows.Forms.Panel();
            this.cbAccurate = new System.Windows.Forms.CheckBox();
            this.PanelHotkey = new System.Windows.Forms.Panel();
            this.PanelSet = new System.Windows.Forms.Panel();
            this.PanelAbout = new System.Windows.Forms.Panel();
            this.textBoxAbout = new System.Windows.Forms.TextBox();
            this.PictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.PanelBaidu.SuspendLayout();
            this.PanelHotkey.SuspendLayout();
            this.PanelSet.SuspendLayout();
            this.PanelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxMenu
            // 
            this.ListBoxMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBoxMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBoxMenu.FormattingEnabled = true;
            this.ListBoxMenu.ItemHeight = 21;
            this.ListBoxMenu.Items.AddRange(new object[] {
            " 百度接口",
            " 热键",
            " 关于"});
            this.ListBoxMenu.Location = new System.Drawing.Point(5, 5);
            this.ListBoxMenu.Name = "ListBoxMenu";
            this.ListBoxMenu.Size = new System.Drawing.Size(85, 233);
            this.ListBoxMenu.TabIndex = 9;
            this.ListBoxMenu.SelectedIndexChanged += new System.EventHandler(this.ListBoxMenu_SelectedIndexChanged);
            // 
            // TextBoxHotkey
            // 
            this.TextBoxHotkey.BackColor = System.Drawing.Color.White;
            this.TextBoxHotkey.Location = new System.Drawing.Point(86, 11);
            this.TextBoxHotkey.Name = "TextBoxHotkey";
            this.TextBoxHotkey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxHotkey.TabIndex = 6;
            this.TextBoxHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxHotkey_KeyDown);
            this.TextBoxHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxHotkey_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "截图识别：";
            // 
            // TextBoxToken
            // 
            this.TextBoxToken.BackColor = System.Drawing.Color.White;
            this.TextBoxToken.Location = new System.Drawing.Point(88, 73);
            this.TextBoxToken.Name = "TextBoxToken";
            this.TextBoxToken.Size = new System.Drawing.Size(225, 21);
            this.TextBoxToken.TabIndex = 3;
            // 
            // TextBoxSecretKey
            // 
            this.TextBoxSecretKey.BackColor = System.Drawing.Color.White;
            this.TextBoxSecretKey.Location = new System.Drawing.Point(88, 43);
            this.TextBoxSecretKey.Name = "TextBoxSecretKey";
            this.TextBoxSecretKey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxSecretKey.TabIndex = 2;
            // 
            // TextBoxApiKey
            // 
            this.TextBoxApiKey.BackColor = System.Drawing.Color.White;
            this.TextBoxApiKey.Location = new System.Drawing.Point(88, 13);
            this.TextBoxApiKey.Name = "TextBoxApiKey";
            this.TextBoxApiKey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxApiKey.TabIndex = 1;
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.White;
            this.ButtonSave.Location = new System.Drawing.Point(286, 244);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "确认";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonApiTest
            // 
            this.ButtonApiTest.BackColor = System.Drawing.Color.White;
            this.ButtonApiTest.Location = new System.Drawing.Point(238, 129);
            this.ButtonApiTest.Name = "ButtonApiTest";
            this.ButtonApiTest.Size = new System.Drawing.Size(75, 23);
            this.ButtonApiTest.TabIndex = 5;
            this.ButtonApiTest.Text = "密钥测试";
            this.ButtonApiTest.UseVisualStyleBackColor = false;
            this.ButtonApiTest.Click += new System.EventHandler(this.ButtonApiTest_Click);
            // 
            // ButtonAapply
            // 
            this.ButtonAapply.BackColor = System.Drawing.Color.White;
            this.ButtonAapply.Location = new System.Drawing.Point(86, 129);
            this.ButtonAapply.Name = "ButtonAapply";
            this.ButtonAapply.Size = new System.Drawing.Size(75, 23);
            this.ButtonAapply.TabIndex = 4;
            this.ButtonAapply.Text = "接口申请";
            this.ButtonAapply.UseVisualStyleBackColor = false;
            this.ButtonAapply.Click += new System.EventHandler(this.ButtonAapply_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "API Key：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Access Token：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "Secret Key：";
            // 
            // PanelBaidu
            // 
            this.PanelBaidu.Controls.Add(this.cbAccurate);
            this.PanelBaidu.Controls.Add(this.TextBoxToken);
            this.PanelBaidu.Controls.Add(this.label9);
            this.PanelBaidu.Controls.Add(this.label10);
            this.PanelBaidu.Controls.Add(this.label4);
            this.PanelBaidu.Controls.Add(this.ButtonAapply);
            this.PanelBaidu.Controls.Add(this.TextBoxSecretKey);
            this.PanelBaidu.Controls.Add(this.ButtonApiTest);
            this.PanelBaidu.Controls.Add(this.TextBoxApiKey);
            this.PanelBaidu.Location = new System.Drawing.Point(6, 5);
            this.PanelBaidu.Name = "PanelBaidu";
            this.PanelBaidu.Size = new System.Drawing.Size(318, 163);
            this.PanelBaidu.TabIndex = 30;
            // 
            // cbAccurate
            // 
            this.cbAccurate.AutoSize = true;
            this.cbAccurate.Location = new System.Drawing.Point(88, 104);
            this.cbAccurate.Name = "cbAccurate";
            this.cbAccurate.Size = new System.Drawing.Size(108, 16);
            this.cbAccurate.TabIndex = 19;
            this.cbAccurate.Text = "使用高精度接口";
            this.cbAccurate.UseVisualStyleBackColor = true;
            // 
            // PanelHotkey
            // 
            this.PanelHotkey.Controls.Add(this.label3);
            this.PanelHotkey.Controls.Add(this.TextBoxHotkey);
            this.PanelHotkey.Location = new System.Drawing.Point(6, 174);
            this.PanelHotkey.Name = "PanelHotkey";
            this.PanelHotkey.Size = new System.Drawing.Size(318, 41);
            this.PanelHotkey.TabIndex = 31;
            this.PanelHotkey.Visible = false;
            // 
            // PanelSet
            // 
            this.PanelSet.AutoScroll = true;
            this.PanelSet.AutoScrollMinSize = new System.Drawing.Size(100, 500);
            this.PanelSet.BackColor = System.Drawing.Color.White;
            this.PanelSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSet.Controls.Add(this.PanelAbout);
            this.PanelSet.Controls.Add(this.PanelBaidu);
            this.PanelSet.Controls.Add(this.PanelHotkey);
            this.PanelSet.Location = new System.Drawing.Point(96, 5);
            this.PanelSet.Name = "PanelSet";
            this.PanelSet.Size = new System.Drawing.Size(346, 233);
            this.PanelSet.TabIndex = 32;
            // 
            // PanelAbout
            // 
            this.PanelAbout.Controls.Add(this.textBoxAbout);
            this.PanelAbout.Controls.Add(this.PictureBoxIcon);
            this.PanelAbout.Location = new System.Drawing.Point(6, 221);
            this.PanelAbout.Name = "PanelAbout";
            this.PanelAbout.Size = new System.Drawing.Size(318, 162);
            this.PanelAbout.TabIndex = 32;
            this.PanelAbout.Visible = false;
            // 
            // textBoxAbout
            // 
            this.textBoxAbout.BackColor = System.Drawing.Color.White;
            this.textBoxAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAbout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxAbout.Location = new System.Drawing.Point(82, 3);
            this.textBoxAbout.Multiline = true;
            this.textBoxAbout.Name = "textBoxAbout";
            this.textBoxAbout.ReadOnly = true;
            this.textBoxAbout.Size = new System.Drawing.Size(229, 144);
            this.textBoxAbout.TabIndex = 1;
            this.textBoxAbout.Text = "当前版本：1.03\r\n更新日期：2020-09-04\r\n发布地址：仅在吾爱破解论坛发布\r\n                 @旋律丶小飞\r\n反馈邮箱：iPanYJ" +
    "@outlook.com\r\n\r\n本软件仅供学习交流使用";
            // 
            // PictureBoxIcon
            // 
            this.PictureBoxIcon.Image = global::jyocr.Properties.Resources.OCR;
            this.PictureBoxIcon.Location = new System.Drawing.Point(7, 7);
            this.PictureBoxIcon.Name = "PictureBoxIcon";
            this.PictureBoxIcon.Size = new System.Drawing.Size(65, 65);
            this.PictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxIcon.TabIndex = 0;
            this.PictureBoxIcon.TabStop = false;
            // 
            // ButtonExit
            // 
            this.ButtonExit.BackColor = System.Drawing.Color.White;
            this.ButtonExit.Location = new System.Drawing.Point(367, 244);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 23);
            this.ButtonExit.TabIndex = 8;
            this.ButtonExit.Text = "取消";
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // FmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(449, 276);
            this.Controls.Add(this.PanelSet);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ListBoxMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FmSetting_Load);
            this.PanelBaidu.ResumeLayout(false);
            this.PanelBaidu.PerformLayout();
            this.PanelHotkey.ResumeLayout(false);
            this.PanelHotkey.PerformLayout();
            this.PanelSet.ResumeLayout(false);
            this.PanelAbout.ResumeLayout(false);
            this.PanelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxHotkey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxToken;
        private System.Windows.Forms.TextBox TextBoxSecretKey;
        private System.Windows.Forms.TextBox TextBoxApiKey;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonApiTest;
        private System.Windows.Forms.Button ButtonAapply;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox ListBoxMenu;
        private System.Windows.Forms.Panel PanelBaidu;
        private System.Windows.Forms.Panel PanelHotkey;
        private System.Windows.Forms.Panel PanelSet;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Panel PanelAbout;
        private System.Windows.Forms.PictureBox PictureBoxIcon;
        private System.Windows.Forms.TextBox textBoxAbout;
        private System.Windows.Forms.CheckBox cbAccurate;
    }
}