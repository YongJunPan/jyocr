using System.Diagnostics;

namespace jyocr.Unit
{
    class Translate
    {
        public static void goTranslate(string originalText)
        {
            switch (Setting.TranItem)
            {
                case 0:
                    TranslateGoogle(originalText);
                    break;
                case 1:
                    TranslateBaidu(originalText);
                    break;
                case 2:
                    TranslateSogo(originalText);
                    break;
            }
        }

        public static void TranslateGoogle(string originalText)
        {
            string url = "";
            switch (Setting.TranOption)
            {
                case 0:
                    url = string.Format("https://translate.google.cn/?sl=zh-CN&tl=en&text={0}&op=translate", originalText);
                    break;
                case 1:
                    url = string.Format("https://translate.google.cn/?sl=en&tl=zh-CN&text={0}&op=translate", originalText);
                    break;
                case 2:
                    url = string.Format("https://translate.google.cn/?sl=auto&tl=zh-CN&text={0}&op=translate", originalText);
                    break;
            }
            Process.Start(url);
        }

        public static void TranslateBaidu(string originalText)
        {
            string url = "";
            switch (Setting.TranOption)
            {
                case 0:
                    url = string.Format("https://fanyi.baidu.com/#zh/en/{0}", originalText);
                    break;
                case 1:
                    url = string.Format("https://fanyi.baidu.com/#en/zh/{0}", originalText);
                    break;
                case 2:
                    url = string.Format("https://fanyi.baidu.com/#auto/zh/{0}", originalText);
                    break;
            }
            Process.Start(url);
        }

        public static void TranslateSogo(string originalText)
        {
            string url = "";
            switch (Setting.TranOption)
            {
                case 0:
                    url = string.Format("https://fanyi.sogou.com/?keyword={0}&transfrom=zh-CHS&transto=en&model=general", originalText);
                    break;
                case 1:
                    url = string.Format("https://fanyi.sogou.com/?keyword={0}&transfrom=en&transto=zh-CHS&model=general", originalText);
                    break;
                case 2:
                    url = string.Format("https://fanyi.sogou.com/?keyword={0}&transfrom=auto&transto=zh-CHS&model=general", originalText);
                    break;
            }
            Process.Start(url);
        }
    }
}
