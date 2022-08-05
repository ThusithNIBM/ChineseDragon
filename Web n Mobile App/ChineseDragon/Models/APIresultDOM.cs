using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseDragon.Models
{
    public class APIresultDOM<T>
    {
        public T data { get; set; }
        public bool IsSuccess { get; set; }
        public string SvrMsgTitle { get; set; }
        public string SvrMsgBody { get; set; }
    }
}