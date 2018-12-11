using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BL.Services;
using Web.Common.Models;

namespace Web.MVC.Client.Controllers
{
    public class RegisterController : Controller
    {
        public Services Service { get; set; }
        // GET: Register
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegistrationModel newUserInputInfo)
        {
            try
            {
                var newUser = new UserRegistrationModel
                {
                    FirstName = newUserInputInfo.FirstName,
                    LastName = newUserInputInfo.LastName,
                    Password = newUserInputInfo.Password,
                    EmailAddress = newUserInputInfo.EmailAddress
                };

                return RedirectToAction("Index");
            }
            catch
            {
                // Creating User Failed - write to log + show client error page
                return View();
            }
        }
    }
}