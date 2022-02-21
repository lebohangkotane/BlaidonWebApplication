using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BlaidonWebApplication.Models;
using System.Data;
using System.Configuration;

namespace BlaidonWebApplication.Controllers
{
    public class AdminController : Controller
    {
        //sql connection
        string connectionString = ConfigurationManager.ConnectionStrings["BlaidonConnection"].ConnectionString;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection con;
        public AdminController()
        {
            con = new SqlConnection(connectionString);
        }
        public class Myvariables
        {
            public static int x = 0;
            public static int y = 0;
            public static int z = 0;
            public static int a = 0;
        }
        List<Booking> bookings = new List<Booking>();
        List<Enquiry> enquiries = new List<Enquiry>();
        List<Registration> users = new List<Registration>();
        List<AdminClss> adminL = new List<AdminClss>();
        
        
        // GET: Admin
        public ActionResult Dashboard()
        {
            //Products
            ProductPackage pp = new ProductPackage();
            int numberOfProductEnquiries = pp.NumberProductOffering();
            double numbOFOA = pp.NumberofOFOA(numberOfProductEnquiries);
            double numbLFP = pp.NumberofLFP(numberOfProductEnquiries);
            double numbMBFS = pp.NumberofMBFS(numberOfProductEnquiries);
            double numbCSC = pp.NumberofCSC(numberOfProductEnquiries);
            double numbCMF = pp.NumberofCMF(numberOfProductEnquiries);
            double numbCB = pp.NumberofCB(numberOfProductEnquiries);
            double numbPI = pp.NumberofPI(numberOfProductEnquiries);

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Office Furniture and Office Accessories", numbOFOA));
            dataPoints.Add(new DataPoint("Promotional Items", numbPI));
            dataPoints.Add(new DataPoint("Corporate Branding", numbCB));
            dataPoints.Add(new DataPoint("Custom Made Furniture", numbCMF));
            dataPoints.Add(new DataPoint("Corpoate and Safety Clothing", numbCSC));
            dataPoints.Add(new DataPoint("Mobile Bulk Filing Systems", numbMBFS));
            dataPoints.Add(new DataPoint("Large Format Printing", numbLFP));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            //Services
            ServicePackage sp = new ServicePackage();
            int numberOfServiceEnquiries = sp.NumberServiceOffering();
            double numbplbng = sp.NumberofPlbmg(numberOfServiceEnquiries);
            double numbPtng = sp.NumberofPtng(numberOfServiceEnquiries);
            double numbEltcl = sp.NumberofElctl(numberOfServiceEnquiries);
            double numbFlrng = sp.NumberofFlrng(numberOfServiceEnquiries);
            double numbDwllng = sp.NumberofDwllng(numberOfServiceEnquiries);
            double numbBldng = sp.NumberofBldng(numberOfServiceEnquiries);
            double numbRvntn = sp.NumberofRvntn(numberOfServiceEnquiries);

            List<DataPoint> dataPoints1 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("Painting", numbPtng));
            dataPoints1.Add(new DataPoint("Plumbing", numbplbng));
            dataPoints1.Add(new DataPoint("Electrical", numbEltcl));
            dataPoints1.Add(new DataPoint("Flooring", numbFlrng));
            dataPoints1.Add(new DataPoint("Dry Walling", numbDwllng));
            dataPoints1.Add(new DataPoint("Building", numbBldng));
            dataPoints1.Add(new DataPoint("Renovation", numbRvntn));

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            Myvariables.x = NumberofEnquirires();
            Myvariables.y = NumberofServiceR();
            Myvariables.z = NumberofUsers();
            Myvariables.a = NumberofAdmins();
            return View();
        }

        public ActionResult ServiceRequest()
        {
            if (bookings.Count > 0)
            {
                bookings.Clear();
            }           

            //Reading Booking details From our database
            cmd = new SqlCommand("Select * from tblBookings ORDER BY Booking_ID DESC;", con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bookings.Add(new Booking()
                {
                    booking_id = dr["Booking_ID"].ToString()
                ,
                    date_made = dr["Date_Made"].ToString()
                ,
                    user_id = dr["User_ID"].ToString()
                ,
                    service_request = dr["Service_Request"].ToString()
                ,
                    booking_details = dr["Booking_Details"].ToString()
                ,
                    scoped = dr["Scoped"].ToString()
                ,
                    progress = dr["Progress"].ToString()
                ,
                    done = dr["Done"].ToString()
                ,
                });
            }
            con.Close();
            return View(bookings);
        }

        public ActionResult EnquiryRequest()
        {
            if (enquiries.Count > 0)
            {
                enquiries.Clear();
            }
            
            //insert Booking details into our database
            cmd = new SqlCommand("Select * from tblEnquiries ORDER BY Enquiry_ID DESC; ", con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                enquiries.Add(new Enquiry()
                {
                    Enquiry_ID = dr["Enquiry_ID"].ToString()
                ,
                    Date_Made = dr["Date_Made"].ToString()
                ,
                    Email = dr["Email"].ToString()
                ,
                    category = dr["Category"].ToString()
                ,
                    type = dr["Type"].ToString()
                ,
                    Message_Enquiry = dr["Message_Enquiry"].ToString()
                ,
                });
            }
            con.Close();
            return View(enquiries);
        }

        public ActionResult EditUsers()
        {
            if (users.Count > 0)
            {
                users.Clear();
            }
          
            //insert Booking details into our database
            cmd = new SqlCommand("Select * from tblUsers ORDER BY User_ID DESC; ", con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                users.Add(new Registration()
                {
                    User_Identity = dr["User_ID"].ToString()
                ,
                    Date_Made = dr["Date_Created"].ToString()
                ,
                    Email_add = dr["Username"].ToString()
                ,
                    FName = dr["FName"].ToString()
                ,
                    LName = dr["LName"].ToString()
                ,
                    Phone_No = dr["Phone_No"].ToString()
                ,
                });
            }
            con.Close();
            return View(users);
        }

        public ActionResult EditAdmins()
        {
            if (adminL.Count > 0)
            {
                adminL.Clear();
            }
            
            //insert Booking details into our database
            cmd = new SqlCommand("Select * from tblAdministration ORDER BY Admin_ID DESC; ", con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                adminL.Add(new AdminClss()
                {
                    Admin_ID = dr["Admin_ID"].ToString()
                ,
                    FName = dr["F_Name"].ToString()
                ,
                    LName = dr["L_Name"].ToString()
                ,
                    Phone_No = dr["Phone_No"].ToString()
                ,
                    Email = dr["Email"].ToString()
                ,
                    Job_Role = dr["Job_Role"].ToString()
                ,
                });
            }
            con.Close();
            return View(adminL);
        }

        public ActionResult AddAdmin(AdminClss adm)
        {
            //create hash from user password
            string p = Convert.ToString(adm.Password_);
            string inputString = p;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            try
            {
                
                //insert Enquiry to our database
                cmd = new SqlCommand(@"INSERT INTO[dbo].[tbladministration]
                ([F_Name], 
                [L_Name],
                [Phone_No],
                [Email],
                [Job_Role],
                [Password])
                VALUES('" + adm.FName + "','" + adm.LName + "','" + adm.Phone_No + "','" + adm.Email + "','" + adm.Job_Role + "','" + hash + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Admin added Successfully.');</script>");
                con.Close();
                EditAdmins();
                return View("EditAdmins");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Unsuccessful, Please try again. ');</script>");
                EditAdmins();
                return View("EditAdmins");
                throw;
            }
        }

        public ActionResult DlteAdmin(AdminClss adm)
        {
            //Delete Enquiry to our database
            cmd = new SqlCommand("DELETE FROM tblAdministration WHERE Admin_ID= " + adm.Admin_ID, con);
            SqlCommand cmdr = new SqlCommand("Select * From tblAdministration WHERE Admin_ID= " + adm.Admin_ID, con);

            try
            {
                SqlDataReader drS;
                con.Open();
                drS = cmdr.ExecuteReader();
                if (drS.HasRows)
                {
                    if (adm.Password_ == "DELETE")
                    {
                        con.Close();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Employee Deleted Successfully.');</script>");
                        con.Close();
                        EditAdmins();
                        return View("EditAdmins");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Password. Please try again');</script>");
                        con.Close();
                        EditAdmins();
                        return View("EditAdmins");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Admin does not Exist');</script>");
                    con.Close();
                    EditAdmins();
                    return View("EditAdmins");
                }
               
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops, Something went wrong. Please try again.');</script>");
                con.Close();
                EditAdmins();
                return View("EditAdmins");
                throw;
            }
        }

        public ActionResult DlteUsrs(Account acnt)
        {
            
            //Delete Enquiry to our database
            cmd = new SqlCommand("DELETE FROM tblUsers WHERE User_ID= " + acnt.User_Identity, con);
            SqlCommand cmdr = new SqlCommand("Select * From tblUsers WHERE User_ID= " + acnt.User_Identity, con);

            try
            {
                SqlDataReader drS;
                con.Open();
                drS = cmdr.ExecuteReader();
                if (drS.HasRows)
                {
                    con.Close();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('User Deleted Successfully.');</script>");
                    con.Close();
                    EditUsers();
                    return View("EditUsers");
                }
                else
                {
                    Response.Write("<script>alert('User does not Exist. Please try again.');</script>");
                    con.Close();
                    EditUsers();
                    return View("EditUsers");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops, Something went wrong. Please try again.');</script>");
                con.Close();
                EditUsers();
                return View("EditUsers");
                throw;
            }
        }

        public ActionResult DlteEqrs(Enquiry eqrs)
        {
            //Delete Enquiry to our database
            cmd = new SqlCommand("DELETE FROM tblEnquiries WHERE Enquiry_ID= " + eqrs.Enquiry_ID, con);
            SqlCommand cmdr = new SqlCommand("Select * From tblEnquiries WHERE Enquiry_ID= " + eqrs.Enquiry_ID, con);

            try
            {
                SqlDataReader drS;
                con.Open();
                drS = cmdr.ExecuteReader();
                if (drS.HasRows)
                {
                    con.Close();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Enquiry Record Deleted Successfully.');</script>");
                    con.Close();
                    EnquiryRequest();
                    return View("EnquiryRequest");
                }
                else
                {
                    Response.Write("<script>alert('Enquiry Record does not Exist. Please try again.');</script>");
                    con.Close();
                    EnquiryRequest();
                    return View("EnquiryRequest");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops, Something went wrong. Please Try again.');</script>");
                con.Close();
                EnquiryRequest();
                return View("EnquiryRequest");
                throw;
            }
        }


        //Number of Sections
        public int NumberofEnquirires()
        {
            //number of Enquiries
            int numofRowsE;
            string numRsE = "";

            con.Open();
            SqlCommand cmdNumR = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries; ", con);

            using (dr = cmdNumR.ExecuteReader())
            {
                while (dr.Read())
                {
                    numRsE = dr[0].ToString();
                }
            }

            numofRowsE = Convert.ToInt32(numRsE);
            con.Close();
            return numofRowsE;
        }
        public int NumberofServiceR()
        {
            //number of ServiceRequests
            int numofRowsSR;
            string numRSR = "";

            con.Open();
            SqlCommand cmdNumR = new SqlCommand("SELECT COUNT(Booking_ID) FROM tblBookings; ", con);

            using (dr = cmdNumR.ExecuteReader())
            {
                while (dr.Read())
                {
                    numRSR = dr[0].ToString();
                }
            }

            numofRowsSR = Convert.ToInt32(numRSR);
            con.Close();
            return numofRowsSR;
        }
        public int NumberofUsers()
        {
            //number of Users
            int numofRowsU;
            string numRSU = "";

            con.Open();
            SqlCommand cmdNumRU = new SqlCommand("SELECT COUNT(User_ID) FROM tblUsers; ", con);

            using (dr = cmdNumRU.ExecuteReader())
            {
                while (dr.Read())
                {
                    numRSU = dr[0].ToString();
                }
            }

            numofRowsU = Convert.ToInt32(numRSU);
            con.Close();
            return numofRowsU;
        }
        public int NumberofAdmins()
        {
            //number of Admins
            int numofRowsA;
            string numRSA = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(Admin_ID) FROM tbladministration; ", con);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numRSA = dr[0].ToString();
                }
            }

            numofRowsA = Convert.ToInt32(numRSA);
            con.Close();
            return numofRowsA;
        }

        public class GlblNum
        {
            public static string num = "";
        }

        //updating Bookings
        public ActionResult UpdtSRqst(Booking bRqst)
        {
            string scoped = bRqst.scoped;
            string progress = bRqst.progress;
            string done = bRqst.done;
            int id = int.Parse(bRqst.booking_id);
            
            try
            {
                SqlDataReader drS;
                SqlCommand cmdr;
                string sltQuery = "Select * From tblBookings WHERE Booking_ID=@ui";
                using (cmdr= new SqlCommand(sltQuery,con)) 
                {
                    var idnty = cmdr.Parameters.Add("@ui", SqlDbType.Int);
                    idnty.Value = id;
                    con.Open();
                    drS = cmdr.ExecuteReader();
                }
                    
                if (drS.HasRows)
                {
                    con.Close();
                    con.Open();
                    //Update Enquiry to our database
                    string sqlQuery = "update tblBookings set Scoped=@sc, Progress=@pro,Done=@do where Booking_ID=@bokid";
                    using (cmd = new SqlCommand(sqlQuery, con))
                    {
                        var s = cmd.Parameters.Add("@sc", SqlDbType.NVarChar);
                        var p = cmd.Parameters.Add("@pro", SqlDbType.NVarChar);
                        var d = cmd.Parameters.Add("@do", SqlDbType.NVarChar);
                        var bid = cmd.Parameters.Add("@bokid", SqlDbType.Int);

                        s.Value = scoped;
                        p.Value = progress;
                        d.Value = done;
                        bid.Value = id;

                        dr = cmd.ExecuteReader();
                    }

                    Response.Write("<script>alert('Tracking Successfully Updated.');</script>");
                    con.Close();
                    ServiceRequest();
                    return View("ServiceRequest");
                }
                else
                {
                    Response.Write("<script>alert('Booking ID Record does not Exist. Please try again.');</script>");
                    con.Close();
                    ServiceRequest();
                    return View("ServiceRequest");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Unsuccessful.');</script>");
                ServiceRequest();
                return View("ServiceRequest");
                throw;
            }
        }

    }
}