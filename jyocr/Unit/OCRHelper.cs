using jyocr.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;

namespace jyocr.Unit
{
    class OCRHelper
    {
        
        public static string split_txt;
        public static string typeset_txt;

        #pragma warning disable 0649
        public static string ApiKey;
        public static string SecretKey;
        public static string AccessToken;
        public static string DateToken;
        #pragma warning restore 0649

        #region 获取百度 access token
        public static string GetBaiduToken(string api_key, string secret_key)
        {
            try
            {
                string url = "https://aip.baidubce.com/oauth/2.0/token";
                string data = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}", api_key, secret_key);
                string result = HttpClient.Post(data, url);
                BaiduToken token = JsonConvert.DeserializeObject<BaiduToken>(result);
                if (string.IsNullOrEmpty(token.error) == false)
                {
                    return "错误：" + token.error + "：" + token.error_description;
                }
                else
                {
                    return token.access_token.Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 百度通用文字识别
        public static string BaiduBasic(string filePath, Image img = null)
        {
            if (AccessToken == "")
            {
                return "错误：请检查接口设置！";
            }

            string base64 = "";
            string returnStr = "";
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=" + AccessToken;

            if (img == null)
            {
                base64 = Base64Helper.getFileBase64(filePath); // 图片文件的 base64 编码
            }
            else
            {
                base64 = Base64Helper.getFileBase64("", Base64Helper.ImgToBytes(img)); // 剪切板图片的 base64 编码
            }

            string data = "image=" + HttpUtility.UrlEncode(base64);
            string result = HttpClient.Post(data, host);
            var jArray = JArray.Parse(((JObject)JsonConvert.DeserializeObject(result))["words_result"].ToString());
            returnStr = checked_txt(jArray, 1, "words");

            return returnStr;
        }
        #endregion

        #region 智能段落合并
        public static string checked_txt(JArray jarray, int lastlength, string words)
        {
            var num = 0;
            for (var i = 0; i < jarray.Count; i++)
            {
                var length = JObject.Parse(jarray[i].ToString())[words].ToString().Length;
                if (length > num)
                {
                    num = length;
                }
            }
            var str = "";
            var text = "";
            for (var j = 0; j < jarray.Count - 1; j++)
            {
                var jobject = JObject.Parse(jarray[j].ToString());
                var array = jobject[words].ToString().ToCharArray();
                var jobject2 = JObject.Parse(jarray[j + 1].ToString());
                var array2 = jobject2[words].ToString().ToCharArray();
                var length2 = jobject[words].ToString().Length;
                var length3 = jobject2[words].ToString().Length;
                if (Math.Abs(length2 - length3) <= 0)
                {
                    if (split_paragraph(array[array.Length - lastlength].ToString()) && contain_en(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else if (split_paragraph(array[array.Length - lastlength].ToString()) && IsNum(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else if (split_paragraph(array[array.Length - lastlength].ToString()) && Is_punctuation(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else
                    {
                        text += jobject[words].ToString().Trim();
                    }
                }
                else if (split_paragraph(array[array.Length - lastlength].ToString()) && Math.Abs(length2 - length3) <= 1)
                {
                    if (split_paragraph(array[array.Length - lastlength].ToString()) && contain_en(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else if (split_paragraph(array[array.Length - lastlength].ToString()) && IsNum(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else if (split_paragraph(array[array.Length - lastlength].ToString()) && Is_punctuation(array2[0].ToString()))
                    {
                        text = text + jobject[words].ToString().Trim() + "\r\n";
                    }
                    else
                    {
                        text += jobject[words].ToString().Trim();
                    }
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && length2 <= num / 2)
                {
                    text = text + jobject[words].ToString().Trim() + "\r\n";
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && IsNum(array2[0].ToString()) && length3 - length2 < 4 && array2[1].ToString() == ".")
                {
                    text = text + jobject[words].ToString().Trim() + "\r\n";
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && contain_ch(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (contain_en(array[array.Length - lastlength].ToString()) && contain_en(array2[0].ToString()))
                {
                    text = text + jobject[words].ToString().Trim() + " ";
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && contain_en(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (contain_en(array[array.Length - lastlength].ToString()) && contain_ch(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && Is_punctuation(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (Is_punctuation(array[array.Length - lastlength].ToString()) && contain_ch(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (Is_punctuation(array[array.Length - lastlength].ToString()) && contain_en(array2[0].ToString()))
                {
                    text = text + jobject[words].ToString().Trim() + " ";
                }
                else if (contain_ch(array[array.Length - lastlength].ToString()) && IsNum(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (IsNum(array[array.Length - lastlength].ToString()) && contain_ch(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else if (IsNum(array[array.Length - lastlength].ToString()) && IsNum(array2[0].ToString()))
                {
                    text += jobject[words].ToString().Trim();
                }
                else
                {
                    text = text + jobject[words].ToString().Trim() + "\r\n";
                }
                if (has_punctuation(jobject[words].ToString()))
                {
                    text += "\r\n";
                }
                str = str + jobject[words].ToString().Trim() + "\r\n";
            }
            split_txt = str + JObject.Parse(jarray[jarray.Count - 1].ToString())[words];
            typeset_txt = text.Replace("\r\n\r\n", "\r\n") + JObject.Parse(jarray[jarray.Count - 1].ToString())[words];
            return text.Replace("\r\n\r\n", "\r\n") + JObject.Parse(jarray[jarray.Count - 1].ToString())[words];
        }
        public static bool IsNum(string str)
        {
            return Regex.IsMatch(str, "^\\d+$");
        }
        public static bool split_paragraph(string text)
        {
            return "。？！?!：".IndexOf(text, StringComparison.Ordinal) != -1;
        }
        public static bool has_punctuation(string text)
        {
            return ",;，；、<>《》()-（）".IndexOf(text) != -1;
        }
        public static bool Is_punctuation(string text)
        {
            return ",;:，（）、；".IndexOf(text) != -1;
        }
        public static bool contain_ch(string str)
        {
            return Regex.IsMatch(str, "[\\u4e00-\\u9fa5]");
        }
        public static bool contain_en(string str)
        {
            return Regex.IsMatch(str, "[a-zA-Z]");
        }
        #endregion

    }
}
