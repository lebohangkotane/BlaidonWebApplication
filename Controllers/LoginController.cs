using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlaidonWebApplication.Models;
using System.Data.SqlClient;
using System.Data;
using Recaptcha.Web.Mvc;
using Recaptcha.Web;


namespace BlaidonWebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        //public variables--
        public class Global 
        {
            public static string uiAStrg; 
        }

        // SQL configerations (User)
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // SQL configerations (Admin)
        SqlConnection conA = new SqlConnection();
        SqlCommand comA = new SqlCommand();
        SqlDataReader drA; 

        //sql connection 
        void connectionString()
        {
            
            con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI; ";
        }
        void connectionStringAdmin()
        {

            conA.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //conA.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
        }

        [HttpPost]
        public ActionResult LoginUser(Account acc)
        {
            //create hash/ Unhash for user / admin password
            string inputString = acc.Password;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);


            //using sql connection check to see if user is in our databse
            connectionStringAdmin();
            conA.Open();

            string sql = "select * from tblAdministration where Email=@username and password=@hash;";
            using (comA = new SqlCommand(sql, conA))
            {
                var username = comA.Parameters.Add("@username", SqlDbType.NVarChar);
                var password = comA.Parameters.Add("@hash", SqlDbType.NVarChar);
                username.Value = acc.UserName;
                password.Value = hash;
                drA = comA.ExecuteReader();
            }

            if (drA.Read())
            {
                Session["UserID"] = acc.UserName.ToString();
                var uiA = (string)Session["UserID"];
                Global.uiAStrg = uiA.ToString();
                conA.Close();
                Response.Write("<script>alert('Login Successful, Welcome Admin.');</script>");

                //returning admin to Dashboard
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                conA.Close();
                //using sql connection check to see if user is in our databse
                connectionString();
                con.Open();

                string sqlQuery = "select * from tblLoginCredentials where username=@username and password=@hash;";
                using (com = new SqlCommand(sqlQuery, con))
                {
                    var username = com.Parameters.Add("@username", SqlDbType.NVarChar);
                    var password = com.Parameters.Add("@hash", SqlDbType.NVarChar);
                    username.Value = acc.UserName;
                    password.Value = hash;
                    dr = com.ExecuteReader();
                }
                if (dr.Read())
                {
                    Session["UserID"] = acc.UserName.ToString();
                    var uiA = (string)Session["UserID"];
                    Global.uiAStrg = uiA.ToString();
                    con.Close();
                    Response.Write("<script>alert('Login Successful');</script>");
                    return RedirectToAction("Users", "Account");
                }
                else
                {
                    Response.Write("<script>alert('Oops!! Incorrect Username or Password, Please try again.');</script>");
                    con.Close();
                    return View("Login");
                }
            }
        }
    }
}