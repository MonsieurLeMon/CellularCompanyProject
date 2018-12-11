using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Client.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Contact()
        {
            return View();
        }
    }
}