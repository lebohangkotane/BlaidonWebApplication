using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlaidonWebApplication.Controllers
{
    public class TCPPController : Controller
    {
        // GET: TCPP
        public ActionResult TC()
        {
            return View();
        }

        public ActionResult PP() 
        {
            return View();
        }
    }
}