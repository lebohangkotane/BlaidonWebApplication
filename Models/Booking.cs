using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class Booking
    {
        public string booking_id { get; set; }
        public string service_request { get; set; }
        public string booking_details { get; set; }
        public string user_id { get; set; }
        public string date_made { get; set; }
        public string scoped { get; set; }
        public string progress { get; set; }
        public string done { get; set; }


        
    }
}