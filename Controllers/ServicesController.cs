using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using BlaidonWebApplication.Models;
using Recaptcha.Web.Mvc;
using Recaptcha.Web;

namespace BlaidonWebApplication.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ServicesSendEmailAsync()
        {
            return View();
        }
        
        //Send Enquiry to Company as an Email 
        [HttpPost]
        public async Task<ActionResult> ServicesSendEmailAsync(Email eml)
        {
            //Verify reCAPTCHA Response
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                Response.Write("<script>alert('Captcha answer cannot be empty.');</script>");
                return View("Services");
                
            }
            
            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (!recaptchaResult.Success)
            {
                Response.Write("<script>alert('Oops, Please check Captcha box again.');</script>");
                return View("Services");
            }
            else
            {
                //Filling enquiry objects and making instances
                Enquiry SPenq = new Enquiry();
                SPenq.Email = eml.cusEmail;
                SPenq.category = eml.category;
                SPenq.type = eml.type;
                SPenq.Message_Enquiry = eml.message;
                eml.to = "aspmailtesting176@gmail.com";
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

                    Response.Write("<script>alert('Enquiry Sent Successfully');</script>");
                    return View("Services");
                }
                catch (Exception ex)
                {

                    Response.Write(ex);
                    Response.Write("<script>alert('Enquiry Unsuccessful, Please try again.');</script>");
                    return View("Services");
                }
            }
            
        }
    }
}