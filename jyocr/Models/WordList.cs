using System;
using System.Collections.Generic;

namespace jyocr.Models
{
    class WordList:TreeObejct
    {
        public string words { get; set; }
        public string result_data { get; set; }
        public string ret_msg { get; set; }
        public int percent { get; set; }
        public int ret_code { get; set; }
        public string request_id { get; set; }
    }
}
