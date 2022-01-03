using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class Email
    {
        public string to { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string cusEmail { get; set; }
        public string details { get; set; }
        public string category { get; set; }
        public string type { get; set; }
    }
}