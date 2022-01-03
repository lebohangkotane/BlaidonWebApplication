using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlaidonWebApplication.Models;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using Recaptcha.Web.Mvc;
using Recaptcha.Web;
using System.Data;

namespace BlaidonWebApplication.Controllers
{
    public class RegistrationController : Controller
    {
        public SmtpDeliveryMethod DeliveryMethod { get; private set; }

        // GET: Registration
        public ActionResult Register()
        {
            return View();
        }


        //Method: Sending data to login table after Registeration
        public void ToLoginTable(string u, string p)
        {
            //create hash from user password
            string inputString = p;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            //sql connection
            SqlConnection con = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            string query = "INSERT INTO tblLoginCredentials(Username, password) VALUES(@username,@password)";
       
            SqlCommand cmd = new SqlCommand(query, con);

            //pass values to parameters
            var usr = cmd.Parameters.Add("@username", SqlDbType.NVarChar);
            var psd = cmd.Parameters.Add("@password", SqlDbType.NVarChar);
            
            usr.Value = u;
            psd.Value = hash;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Registering user
        [HttpPost]
        public ActionResult RegisterUser(Registration reg)
        {
            //Verify reCAPTCHA Response
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                Response.Write("<script>alert('Captcha answer cannot be empty.');</script>");
                return View("Register");
            }

            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (!recaptchaResult.Success)
            {
                Response.Write("<script>alert('Oops, Please check Captcha box again.');</script>");
                return View("Register");
            }
            else
            {
                // sql connection
                SqlConnection conCheck = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlDataReader drSCheck;
                string query = "Select * From tblUsers WHERE username=@email";
                SqlCommand cmdCheckr = new SqlCommand(query, conCheck);
                //pass values to parameters
                var e = cmdCheckr.Parameters.Add("@email", SqlDbType.NVarChar);
                e.Value = reg.Email_add;
                conCheck.Open();
                drSCheck = cmdCheckr.ExecuteReader();
                
                if (drSCheck.HasRows)
                {
                    Response.Write("<script>alert('Email taken. Account already registered.');</script>");
                    conCheck.Close();
                    Register();
                    return View("Register");
                }
                else
                {
                    Session["Email"] = reg.Email_add;
                    Session["FName"] = reg.FName;
                    Session["LName"] = reg.LName;
                    Session["PhoneNo"] = reg.Phone_No;
                    Session["Password"] = reg.Password;

                    //OTP Generation
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

                    string email = reg.Email_add;
                    MailMessage mailMessage = new MailMessage("aspmailtesting176@gmail.com", email);
                    mailMessage.Subject = "Email Verification";
                    mailMessage.Body = "Good Day" + Environment.NewLine + "Please find the OTP to verify your email down below: " + Environment.NewLine + Environment.NewLine + "OTP: " + otp;
                    mailMessage.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("aspmailtesting176@gmail.com", "dswfzxabbrvrewat");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mailMessage);
                    Response.Write("<script>alert('A One Time Pin (OTP) has been sent to your Email Adresss, Please check your Email. ');</script>");
                    return View("OTP");
                }
            }
        }
        
        public ActionResult ConfirmOTP(Registration r) 
        {
            if (Session["emailOTP"].ToString() == r.OTP)
            {
                //sql connection
                SqlConnection con = new SqlConnection("Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                //adding sessions into varibles
                string eml = Session["Email"].ToString();
                string fn = Session["FName"].ToString();
                string ln = Session["LName"].ToString();
                string phn = Session["PhoneNo"].ToString();

                //Register user into our database(User Table)
                string query = "INSERT INTO tblUsers(Username, FName, LName, Phone_No) VALUES(@e,@f,@l,@p)";
                SqlCommand cmd = new SqlCommand(query, con);

                //pass values to parameters
                var email = cmd.Parameters.Add("@e", SqlDbType.NVarChar);
                var firstname = cmd.Parameters.Add("@f", SqlDbType.NVarChar);
                var lastname = cmd.Parameters.Add("@l", SqlDbType.NVarChar);
                var phonenumber = cmd.Parameters.Add("@p", SqlDbType.NVarChar);

                email.Value = eml;
                firstname.Value = fn;
                lastname.Value = ln;
                phonenumber.Value = phn;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //sending new account to login table
                ToLoginTable(Session["Email"].ToString(), Session["Password"].ToString());
                Response.Write("<script>alert('Registered Successfully. Please proceed to Login');</script>");
                return View("Register");
                
            }
            else
            {
                ViewBag.otp = "incorrect OPT Entered";
                return View("OTP");
            }
        }
    }
}