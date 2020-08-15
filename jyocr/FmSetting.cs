using jyocr.Unit;
using jyocr.Models;
using Newtonsoft.Json;
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

        private void ButtonAapply_Click(object sender, EventArgs e)
        {
            Process.Start("https://console.bce.baidu.com/ai/");
        }

        private void ButtonApiTest_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://aip.baidubce.com/oauth/2.0/token";
                string data = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}", TextBoxApiKey.Text, TextBoxSecretKey.Text);
                string result = HttpClient.Post(data, url);
                BaiduToken token = JsonConvert.DeserializeObject<BaiduToken>(result);
                if (string.IsNullOrEmpty(token.error) == false)
                {
                    MessageBox.Show(this, token.error + "：" + token.error_description, "错误");
                }
                else
                {
                    TextBoxToken.Text = token.access_token.Trim();
                    MessageBox.Show(this, "已生成密钥，有效期30天！", "提示");
                }
            }
            catch(Exception ex)
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

            // 刷新变量
            OCRHelper.ApiKey = TextBoxApiKey.Text.Trim();
            OCRHelper.SecretKey = TextBoxSecretKey.Text.Trim();
            OCRHelper.AccessToken = TextBoxToken.Text.Trim();

            MessageBox.Show(this, "配置已保存！", "提示");
        }

        private void FmSetting_Load(object sender, EventArgs e)
        {
            TextBoxApiKey.Text = OCRHelper.ApiKey;
            TextBoxSecretKey.Text = OCRHelper.SecretKey;
            TextBoxToken.Text = OCRHelper.AccessToken;
        }
    }
}
