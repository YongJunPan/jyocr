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
            this.TextBoxSecretKey = new System.Windows.Forms.TextBox();
            this.TextBoxApiKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ButtonAapply = new System.Windows.Forms.Button();
            this.ButtonApiTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxHotkey = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxSecretKey
            // 
            this.TextBoxSecretKey.BackColor = System.Drawing.Color.White;
            this.TextBoxSecretKey.Location = new System.Drawing.Point(95, 75);
            this.TextBoxSecretKey.Name = "TextBoxSecretKey";
            this.TextBoxSecretKey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxSecretKey.TabIndex = 2;
            // 
            // TextBoxApiKey
            // 
            this.TextBoxApiKey.BackColor = System.Drawing.Color.White;
            this.TextBoxApiKey.Location = new System.Drawing.Point(95, 45);
            this.TextBoxApiKey.Name = "TextBoxApiKey";
            this.TextBoxApiKey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxApiKey.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Secret Key：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "API Key：";
            // 
            // ButtonAapply
            // 
            this.ButtonAapply.BackColor = System.Drawing.Color.White;
            this.ButtonAapply.Location = new System.Drawing.Point(95, 132);
            this.ButtonAapply.Name = "ButtonAapply";
            this.ButtonAapply.Size = new System.Drawing.Size(75, 23);
            this.ButtonAapply.TabIndex = 3;
            this.ButtonAapply.Text = "接口申请";
            this.ButtonAapply.UseVisualStyleBackColor = false;
            this.ButtonAapply.Click += new System.EventHandler(this.ButtonAapply_Click);
            // 
            // ButtonApiTest
            // 
            this.ButtonApiTest.BackColor = System.Drawing.Color.White;
            this.ButtonApiTest.Location = new System.Drawing.Point(245, 132);
            this.ButtonApiTest.Name = "ButtonApiTest";
            this.ButtonApiTest.Size = new System.Drawing.Size(75, 23);
            this.ButtonApiTest.TabIndex = 4;
            this.ButtonApiTest.Text = "密钥测试";
            this.ButtonApiTest.UseVisualStyleBackColor = false;
            this.ButtonApiTest.Click += new System.EventHandler(this.ButtonApiTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "百度接口";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(2, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 1);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "热键";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "截图识别：";
            // 
            // TextBoxHotkey
            // 
            this.TextBoxHotkey.BackColor = System.Drawing.Color.White;
            this.TextBoxHotkey.Location = new System.Drawing.Point(95, 225);
            this.TextBoxHotkey.Name = "TextBoxHotkey";
            this.TextBoxHotkey.Size = new System.Drawing.Size(225, 21);
            this.TextBoxHotkey.TabIndex = 5;
            this.TextBoxHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxHotkey_KeyDown);
            this.TextBoxHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxHotkey_KeyUp);
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.White;
            this.ButtonSave.Location = new System.Drawing.Point(245, 280);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "保存设置";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(2, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 1);
            this.panel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Access Token：";
            // 
            // TextBoxToken
            // 
            this.TextBoxToken.BackColor = System.Drawing.Color.White;
            this.TextBoxToken.Location = new System.Drawing.Point(95, 105);
            this.TextBoxToken.Name = "TextBoxToken";
            this.TextBoxToken.Size = new System.Drawing.Size(225, 21);
            this.TextBoxToken.TabIndex = 2;
            // 
            // FmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.TextBoxHotkey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxToken);
            this.Controls.Add(this.TextBoxSecretKey);
            this.Controls.Add(this.TextBoxApiKey);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonApiTest);
            this.Controls.Add(this.ButtonAapply);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxSecretKey;
        private System.Windows.Forms.TextBox TextBoxApiKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ButtonAapply;
        private System.Windows.Forms.Button ButtonApiTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxHotkey;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxToken;
    }
}