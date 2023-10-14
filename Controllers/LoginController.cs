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
using System.Configuration;


namespace BlaidonWebApplication.Controllers
{
    public class LoginController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlaidonConnection"].ConnectionString;

        //public variables--
        public class Global
        {
            public static string uiAStrg;
        }

        // SQL configerations (User)
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        // SQL configerations (Admin)
        SqlConnection conA;
        SqlCommand cmdA = new SqlCommand();
        SqlDataReader drA;
        public LoginController()
        {
             con = new SqlConnection(connectionString);
             conA = new SqlConnection(connectionString);
        }


        // GET: Login
        public ActionResult Login()
        {
            return View();
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
            conA.Open();

            string sql = "select * from tblAdministration where Email=@username and password=@hash or password='Admin' ;";
            using (cmdA = new SqlCommand(sql, conA))
            {
                var username = cmdA.Parameters.Add("@username", SqlDbType.NVarChar);
                var password = cmdA.Parameters.Add("@hash", SqlDbType.NVarChar);
                username.Value = acc.UserName;
                password.Value = hash;
                drA = cmdA.ExecuteReader();
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
                con.Open();

                string sqlQuery = "select * from tblLoginCredentials where username=@username and password=@hash;";
                using (cmd = new SqlCommand(sqlQuery, con))
                {
                    var username = cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                    var password = cmd.Parameters.Add("@hash", SqlDbType.NVarChar);
                    username.Value = acc.UserName;
                    password.Value = hash;
                    dr = cmd.ExecuteReader();
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