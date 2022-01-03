using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using BlaidonWebApplication.Models;
using System.Data.SqlClient;
using Recaptcha.Web.Mvc;
using Recaptcha.Web;

namespace BlaidonWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexSendEmailAsync()
        {
            return View();
        }


        //Send Enquiry to Company as an Email uisng(JavaScript)
        public async Task<ActionResult> IndxSndEml(Email eml)
        {
            //Verify reCAPTCHA Response
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                Response.Write("<script>alert('Captcha answer cannot be empty.');</script>");
                return View("Index");
            }

            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (!recaptchaResult.Success)
            {
                Response.Write("<script>alert('Oops, Please check Captcha box again.');</script>");
                return View("Index");
            }
            else
            {

                //Filling enquiry objects and making instances
                Enquiry SPenq = new Enquiry();
                SPenq.Email = eml.cusEmail;
                SPenq.category = eml.category;
                SPenq.type = eml.type;
                SPenq.Message_Enquiry = eml.message;
                try
                {
                    var client = new SendGridClient("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");
                    var from = new EmailAddress("aspmailtesting176@gmail.com", "Client");
                    var subject = eml.category;
                    var to = new EmailAddress("aspmailtesting176@gmail.com", "Blaidon Projects and Design");
                    string emaildets = "Customer Email: " + eml.cusEmail;
                    var plainTextContent = emaildets;
                    string c = "Category of Enquiry: ";
                    string t = "Type of Enquiry: ";
                    string htmlMessage = "<p>" + emaildets + "</p>" + c + eml.category + "<p>" + t + eml.type + "</p>" + eml.message + "</p>";
                    var htmlContent = htmlMessage;
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    var response = await client.SendEmailAsync(msg);

                    //using Method to send enquiry copy to database
                    SPenq.ToEnquiryTbl(SPenq);

                    //Response.Write("Enquiry Sent Successfully");
                    Response.Write("<script>alert('Enquiry Sent Successfully');</script>");
                    return View("Index");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Oops, Enquiry Unsuccessful. Please try again.');</script>");
                    return View("Index");
                }
            }

        }
        /*Sending Without Javascript
        [HttpPost]
        public async Task<ActionResult> IndexSendEmailAsync(Email eml)
        {
            eml.to = "aspmailtesting176@gmail.com";
            try
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress(eml.to, "Client");
                var subject = eml.subject;
                var to = new EmailAddress(eml.to, "Blaidon Projects and Design");
                string emaildets = "Customer Email: " + eml.cusEmail;
                eml.details = emaildets;
                var plainTextContent = eml.details;
                string htmlMessage = "<p>" + eml.details + "</p>" + "<p>" + eml.message + "</p>";
                var htmlContent = htmlMessage;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                Response.Write("Enquiry Sent Successfully");
                return View("Index");
                //return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                Response.Write(ex);
                Response.Write("Enquiry Unsuccessful, Please try again.");
                return View("Index");
                //return RedirectToAction("Index", "Home");
            }
        }*/

        //Sending using google port
        //public ActionResult SendEmail(Email eml)
        //{
        //    try
        //    {
        //        eml.to = "aspmailtesting176@gmail.com";
        //        eml.from = "aspmailtesting176@gmail.com";
        //        eml.details = eml.message + "\n" + Environment.NewLine + eml.cusEmail;
        //        MailMessage message = new MailMessage(eml.to, eml.from, eml.subject, eml.details);
        //        message.IsBodyHtml = true;

        //        SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
        //        client.EnableSsl = true;
        //        client.Credentials = new System.Net.NetworkCredential("aspmailtesting176@gmail.com", "admin9876");
        //        client.Send(message);
        //        Response.Write("Booking Made Successfully");
        //        return View("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex);
        //        Response.Write("Booking Unsuccessful");
        //        return View("Index");
        //    }
        //}
    }
}