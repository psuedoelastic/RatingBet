using System;
using System.Collections.Generic;
using System.Text;

using App1.Model;

namespace App1.Data
{
    public class ResultItemReqest<T> where T:Items
    {
        public int status { get; set; }
        public T result { get; set; }
    }
}
