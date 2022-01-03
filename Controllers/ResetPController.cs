using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlaidonWebApplication.Models;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace BlaidonWebApplication.Controllers
{
    public class ResetPController : Controller
    {
        // GET: ResetP
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Emailcheck(Reset er)
        {
            string uemail = er.EmailAdd.ToString();

            // SQL Configurations
            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();
            con.Open();
            string sql = "select * from tblLoginCredentials where Username=@email;";
            using (com = new SqlCommand(sql, con))
            {
                var email = com.Parameters.Add("@email", SqlDbType.NVarChar);
                email.Value = er.EmailAdd;
                dr = com.ExecuteReader();
            }

            if (dr.Read())
            {
                Session["EmailID"] = uemail;
                con.Close();

                string Generate_otp()
                {
                    char[] charArr = "0123456789".ToCharArray();
                    string strrandom = string.Empty;
                    Random objran = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        //Excludes Repetation of Characters
                        int pos = objran.Next(1, charArr.Length);
                        if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                        else i--;
                    }
                    return strrandom;
                }
                //OTP Generation
                string otp = Generate_otp();
                Session["emailOTP"] = otp;

                string email = er.EmailAdd;
                MailMessage mailMessage = new MailMessage("aspmailtesting176@gmail.com", email);
                mailMessage.Subject = "Email Verification";
                mailMessage.Body = "Good Day," + Environment.NewLine + "Please find the OTP to verify your email down below: " + Environment.NewLine + Environment.NewLine + "OTP: " + otp;
                mailMessage.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential("aspmailtesting176@gmail.com", "dswfzxabbrvrewat");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.Send(mailMessage);
                Response.Write("<script>alert('A One Time Pin (OTP) has been sent to your Email Adresss, Please check your Email. ');</script>");
                return View("OTP");
            }
            else
            {
                Response.Write("<script>alert('Email not Found, Please try again. ');</script>");
                con.Close();
                return View("ForgotPassword");
            }
        }

        public ActionResult ConfirmOTP(Reset cotp)
        {
            if (Session["emailOTP"].ToString() == cotp.OTP)
            {
                return View("ResetPassword");

            }
            else
            {
                ViewBag.otp = "incorrect OPT Entered";
                return View("OTP");
            }
        }

        public ActionResult NewPassword(Reset pcp)
        {
            string Password = pcp.password;
            string CPassword = pcp.confirm_password;
            var usreml = (string)Session["EmailID"];
            
            string useremail = usreml.ToString();
            pcp.ToLoginTable(useremail, Password);
            Response.Write("<script>alert('Your New Password has been saved. Please Login to Confirm. ');</script>");
            Response.Write("Your New Password has been saved. Please Login to Confirm.");
            return View("ResetPassword");
        }
    }
}