﻿using System.Collections.Generic;

namespace jyocr.Models
{
    class TreeObejct
    {
        public string log_id { get; set; }
        public int words_result_num { get; set; }
        public List<WordList> words_result { get; set; }
        public List<WordList> result { get; set; }
    }
}
