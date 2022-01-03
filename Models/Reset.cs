using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class Reset
    {
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


            // SQL Configurations
            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection();
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }

            string sql = "Update tblLoginCredentials set Password=@pswd where Username=@email;";
            using (com = new SqlCommand(sql, con))
            {
                var email = com.Parameters.Add("@email", SqlDbType.NVarChar);
                var pswd = com.Parameters.Add("@pswd", SqlDbType.NVarChar);
                email.Value = u;
                pswd.Value = hash;
                connectionStringAdmin();
                con.Open();
                com.ExecuteReader();
                con.Close();
            }
        }
    }
}