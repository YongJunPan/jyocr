using jyocr.Unit;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace jyocr
{
    public partial class FmSetting : Form
    {
        public FmSetting()
        {
            InitializeComponent();
        }

        private void FmSetting_Load(object sender, EventArgs e)
        {
            TextBoxApiKey.Text = OCRHelper.ApiKey;
            TextBoxSecretKey.Text = OCRHelper.SecretKey;
            TextBoxToken.Text = OCRHelper.AccessToken;
            TextBoxHotkey.Text = IniHelper.GetValue("热键", "截图识别");
            cbAccurate.Checked = OCRHelper.Accurate;
            CheckBoxPlus.Checked = Setting.TextPlus;
            CheckBoxCopy.Checked = Setting.TextCopy;
            CheckBoxHide.Checked = Setting.FormHide;
            CheckBoxTray.Checked = Setting.FormTray;
            PanelSet.AutoScroll = false;
        }

        private void ButtonAapply_Click(object sender, EventArgs e)
        {
            Process.Start("https://console.bce.baidu.com/ai/");
        }

        private void ButtonApiTest_Click(object sender, EventArgs e)
        {
            try
            {
                //string url = "https://aip.baidubce.com/oauth/2.0/token";
                //string data = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}", TextBoxApiKey.Text, TextBoxSecretKey.Text);
                //string result = HttpClient.Post(data, url);
                //BaiduToken token = JsonConvert.DeserializeObject<BaiduToken>(result);
                string token = OCRHelper.GetBaiduToken(TextBoxApiKey.Text, TextBoxSecretKey.Text);
                if (token.Contains("错误"))
                {
                    MessageBox.Show(this, token, "错误");
                }
                else
                {
                    TextBoxToken.Text = token;
                    IniHelper.SetValue("百度接口", "API Key", TextBoxApiKey.Text.Trim());
                    IniHelper.SetValue("百度接口", "Secret Key", TextBoxSecretKey.Text.Trim());
                    IniHelper.SetValue("百度接口", "Access Token", TextBoxToken.Text.Trim());
                    IniHelper.SetValue("百度接口", "Date Token", DateTime.Now.ToString("yyyy-MM-dd"));
                    MessageBox.Show(this, "已生成并保存密钥，有效期30天！", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // 保存 ini 配置
            IniHelper.SetValue("百度接口", "API Key", TextBoxApiKey.Text.Trim());
            IniHelper.SetValue("百度接口", "Secret Key", TextBoxSecretKey.Text.Trim());
            IniHelper.SetValue("百度接口", "Access Token", TextBoxToken.Text.Trim());
            IniHelper.SetValue("百度接口", "使用高精度接口", cbAccurate.Checked.ToString());

            IniHelper.SetValue("热键", "截图识别", TextBoxHotkey.Text.Trim());

            IniHelper.SetValue("常规", "识别后文本累加", CheckBoxPlus.Checked.ToString());
            IniHelper.SetValue("常规", "识别后自动复制", CheckBoxCopy.Checked.ToString());
            IniHelper.SetValue("常规", "截图时隐藏窗体", CheckBoxHide.Checked.ToString());
            IniHelper.SetValue("常规", "右下角显示托盘", CheckBoxTray.Checked.ToString());


            // 刷新变量
            OCRHelper.ApiKey = TextBoxApiKey.Text.Trim();
            OCRHelper.SecretKey = TextBoxSecretKey.Text.Trim();
            OCRHelper.AccessToken = TextBoxToken.Text.Trim();
            OCRHelper.Accurate = cbAccurate.Checked;

            Setting.TextPlus = CheckBoxPlus.Checked;
            Setting.TextCopy = CheckBoxCopy.Checked;
            Setting.FormHide = CheckBoxHide.Checked;
            Setting.FormTray = CheckBoxTray.Checked;
            Setting.Hotkey = TextBoxHotkey.Text.Trim();

            //MessageBox.Show(this, "配置已保存！", "提示");
            this.Close();
        }


        #region 识别按下的键盘值
        private void TextBoxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TextBoxHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                TextBoxHotkey.Text = "请按下快捷键";
            }
            else if (e.KeyValue != 16 && e.KeyValue != 17 && e.KeyValue != 18)
            {
                var array = e.KeyData.ToString().Replace(" ", "").Replace("Control", "Ctrl").Split(',');
                if (array.Length == 1)
                {
                    TextBoxHotkey.Text = array[0];
                }
                if (array.Length == 2)
                {
                    TextBoxHotkey.Text = array[1] + "+" + array[0];
                }
            }
        }
        #endregion

        #region 点击左侧导航菜单
        private void ListBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxMenu.SelectedIndex == 0) // 常规
            {
                PanelBaidu.Visible = false;
                PanelHotkey.Visible = false;
                PanelAbout.Visible = false;
                PanelGeneral.Top = ListBoxMenu.Top;
                PanelGeneral.Visible = true;
            }
            else if (ListBoxMenu.SelectedIndex == 1) // 百度接口
            {
                PanelHotkey.Visible = false;
                PanelAbout.Visible = false;
                PanelGeneral.Visible = false;
                PanelBaidu.Top = ListBoxMenu.Top;
                PanelBaidu.Visible = true;
            }
            else if (ListBoxMenu.SelectedIndex == 2) // 热键
            {
                PanelBaidu.Visible = false;
                PanelAbout.Visible = false;
                PanelGeneral.Visible = false;
                PanelHotkey.Top = ListBoxMenu.Top;
                PanelHotkey.Visible = true;
            }
            else if (ListBoxMenu.SelectedIndex == 3) // 关于
            {
                PanelBaidu.Visible = false;
                PanelHotkey.Visible = false;
                PanelGeneral.Visible = false;
                PanelAbout.Top = ListBoxMenu.Top;
                PanelAbout.Visible = true;
            }
        }
        #endregion

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
