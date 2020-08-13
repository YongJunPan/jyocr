using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;


namespace jyocr.Unit
{
    class OCRHelper
    {
        //public static string split_txt;
        //public static string typeset_txt;

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
            // split_txt = str + JObject.Parse(jarray[jarray.Count - 1].ToString())[words];
            // typeset_txt = text.Replace("\r\n\r\n", "\r\n") + JObject.Parse(jarray[jarray.Count - 1].ToString())[words];
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
    }
}
