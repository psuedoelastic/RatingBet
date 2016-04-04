using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class NewsItem: Items
    {
        public int id { get; set; }
        public string preview { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string html { get; set; }
    }
}
