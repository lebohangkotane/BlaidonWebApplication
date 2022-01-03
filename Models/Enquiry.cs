using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BlaidonWebApplication.Models
{
    public class Enquiry
    {
        public string Enquiry_ID { get; set; }
        public string Email { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string Message_Enquiry { get; set; }
        public string Date_Made { get;  set; }

        //Method: Sending Enquiries to database
        public void ToEnquiryTbl(Enquiry eqry)
        {
            //sql connection
            SqlConnection con = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //insert Enquiry to our database
            string query = "INSERT INTO tblEnquiries(Email, Category, Type, Message_Enquiry) VALUES(@e,@c,@t,@m)";
            SqlCommand cmd = new SqlCommand(query, con);

            //pass values to parameters
            var email = cmd.Parameters.Add("@e", SqlDbType.NVarChar);
            var category = cmd.Parameters.Add("@c", SqlDbType.NVarChar);
            var type = cmd.Parameters.Add("@t", SqlDbType.NVarChar);
            var message = cmd.Parameters.Add("@m", SqlDbType.NVarChar);

            email.Value = eqry.Email;
            category.Value = eqry.category;
            type.Value = eqry.type;
            message.Value = eqry.Message_Enquiry;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
