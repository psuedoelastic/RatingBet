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
        public double date { get; set; }
        public DateTime DateT
        {
            get { DateTime origin = new DateTime(1970,1,1,0,0,0,0);
                origin = origin.AddHours(3);
                return origin.AddSeconds(date);
            }
        }
    }
}
