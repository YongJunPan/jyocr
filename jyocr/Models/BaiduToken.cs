using System;

namespace jyocr.Models
{
    class BaiduToken
    {
        public string refresh_token { get; set; }
        public Int32 expires_in { get; set; }
        public string session_key { get; set; }

        /// <summary>
        /// 百度Token，识别接口参数
        /// </summary>
        public string access_token { get; set; }

        public string scope { get; set; }
        public string session_secret { get; set; }

        // 接口访问失败字段
        public string error { get; set; }
        public string error_description { get; set; }

    }
}
