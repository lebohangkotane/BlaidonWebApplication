using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class Registration
    {
        public string User_Identity { get; set; }
        public string Date_Made { get; set; }
        public string Username { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone_No { get; set; }
        public string Email_add { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }

        public string OTP { get; set; }
    }
}