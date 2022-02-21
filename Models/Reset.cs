using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BlaidonWebApplication.Models
{
    public class Reset
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlaidonConnection"].ConnectionString;

        // SQL configerations (User)
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public Reset()
        {
            con = new SqlConnection(connectionString);
        }
        public string EmailAdd { get; set; }
        public string OTP { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }

        public void ToLoginTable(string u, string p)
        {
            //create hash from user password
            string inputString = p;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            //insert user details to Login Credentials 
            string sql = "Update tblLoginCredentials set Password=@pswd where Username=@email;";
            using (cmd = new SqlCommand(sql, con))
            {
                var email = cmd.Parameters.Add("@email", SqlDbType.NVarChar);
                var pswd = cmd.Parameters.Add("@pswd", SqlDbType.NVarChar);
                email.Value = u;
                pswd.Value = hash;
                con.Open();
                cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}