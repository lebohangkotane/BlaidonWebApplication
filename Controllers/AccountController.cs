using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BlaidonWebApplication.Models;
using System.Data;

namespace BlaidonWebApplication.Controllers
{
    public class AccountController : Controller
    {
        List<Booking> bookings = new List<Booking>();
        SqlDataReader dr;
        // GET: Account
        public ActionResult Users()
        {
            //Showing a user's Previous bookings
            if (bookings.Count > 0)
            {
                bookings.Clear();
            }
            //sql connection
            SqlConnection con = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //Reading Booking details From our database
            var ui = (string)Session["UserID"];

            string query = "Select * from tblBookings where User_ID =@usrid ORDER BY Date_Made DESC";
            SqlCommand cmd = new SqlCommand(query, con);

            //pass values to parameters
            var usridnty = cmd.Parameters.Add("@usrid", SqlDbType.NVarChar);
            usridnty.Value = ui;

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bookings.Add(new Booking()
                {
                    date_made = dr["Date_Made"].ToString()
                ,
                    service_request = dr["Service_Request"].ToString()
                ,
                    booking_details = dr["Booking_Details"].ToString()
                ,
                });
            }
            con.Close();
            return View(bookings);
        }

        public ActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Book(Booking bk)
        {
            try
            {
                //sql connection
                SqlConnection con = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                //insert Booking details into our database
                var ui = (string)Session["UserID"];
                bk.user_id = ui;
                
                //sql config
                string query = "INSERT INTO tblBookings(User_ID, Service_Request, Booking_Details) VALUES(@usrid, @sr, @bdetts)";
                SqlCommand cmd = new SqlCommand(query, con);

                //pass values to parameters
                var usridnty = cmd.Parameters.Add("@usrid", SqlDbType.NVarChar);
                var servreqst = cmd.Parameters.Add("@sr", SqlDbType.NVarChar);
                var bookdetts = cmd.Parameters.Add("@bdetts", SqlDbType.NVarChar);

                usridnty.Value = bk.user_id;
                servreqst.Value = bk.service_request;
                bookdetts.Value = bk.booking_details;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Service Request Booked Successfully. You will be Contacted Soon.');</script>");
                Users();
                return View("Users");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops, something went wrong. Please try again.');</script>");
                Users();
                return View("Users");
                throw;
            }      
        }

        public ActionResult DeleteAcc()
        {
            return View();
        }

        public ActionResult DeleteAccount(Account acc) 
        {
            //create hash/ Unhash for user / admin password
            string inputString = acc.Password;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            // SQL configerations (User)
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            void connectionString()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI; ";
            }

            //using sql connection check to see if user is in our databse
            connectionString();
            con.Open();

            //Query declares
            string sqlQuery = "select * from tblLoginCredentials where username=@username and password=@hash;";
            string dltQueryUserTbl = "Delete from tblUsers where Username=@username";
            string dltQueryLoginTbl = "Delete from tblLoginCredentials where Username=@username";
            string dltQueryBookingTbl = "Delete from tblBookings where User_ID=@username";

            //checking login credentials
            using (com = new SqlCommand(sqlQuery, con))
            {
                var username = com.Parameters.Add("@username", SqlDbType.NVarChar);
                var password = com.Parameters.Add("@hash", SqlDbType.NVarChar);
                username.Value = acc.UserName;
                password.Value = hash;
                dr = com.ExecuteReader();
            }

            //user exists proceeding to delete account
            if (dr.Read())
            {
                //Delete User table
                con.Close();
                con.Open();
                using (com = new SqlCommand(dltQueryUserTbl, con))
                {
                    var username = com.Parameters.Add("@username", SqlDbType.NVarChar);
                    username.Value = acc.UserName;
                    dr = com.ExecuteReader();
                }

                //Delete Booking table
                con.Close();
                con.Open();
                using (com = new SqlCommand(dltQueryBookingTbl, con))
                {
                    var username = com.Parameters.Add("@username", SqlDbType.NVarChar);
                    username.Value = acc.UserName;
                    dr = com.ExecuteReader();
                }

                //Delete Login table
                con.Close();
                con.Open();
                using (com = new SqlCommand(dltQueryLoginTbl, con))
                {
                    var username = com.Parameters.Add("@username", SqlDbType.NVarChar);
                    username.Value = acc.UserName;
                    dr = com.ExecuteReader();
                }

                Response.Write("<script>alert('Your Account has been Successfully Deleted. Bye.');</script>");
                return View("DeleteAcc");
            }
            else
            {
                Response.Write("<script>alert('Oops!! Incorrect Username or Password, Please try again.');</script>");
                con.Close();
                return View("DeleteAcc");
            }
        }
    }
}