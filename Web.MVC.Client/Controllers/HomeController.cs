using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BL.Services;
using Web.Common.Models;

namespace Web.MVC.Client.Controllers
{
    public class HomeController : Controller
    {
        public Services Service { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginModel inputUserInfo)
        {
            Service = new Services();
            UserLoginModel user = new UserLoginModel();

            user.PhoneNumber = inputUserInfo.PhoneNumber;
            user.Password = inputUserInfo.Password;

            Service.LogIn(user);

            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Service = new Services();

            Service.GetDetailsForUserById(id);

            return View();
        }

        // GET: Home/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
