using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseDragonMobile.Models
{
    public class OrderCountsDOM
    {
        public int InQueue { get; set; }
        public int Prepared { get; set; }
        public int Cancelled { get; set; }
    }
}