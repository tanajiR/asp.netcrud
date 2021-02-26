using College_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Demo.Controllers
{
    public class AccountController : Controller
    {
        College_DBContext db = new College_DBContext();
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User data)
        {
            db.tbl_user.Add(data);//Insert Operation
            db.SaveChanges();//Commit

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            //select * from tbl_user where email = '@email' and password = '@password'
            //1 1 = 1
            var dbRecord = db.tbl_user.Where(p => p.email.ToLower().Equals(email) && p.password.Equals(password)).FirstOrDefault();
            if (dbRecord != null)
            {
                //login success
                Session["loginUser"] = dbRecord;
                return RedirectToAction("index", "user");
            }
            else {
                //ViewBag
                //TempData
                //Dynamic = ViewBag
                ViewData["msg"] = "Invalid Username/Password";
            }
            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            TempData["msg"] = "Logout Successfully!";
            return RedirectToAction("login", "account");
        }
    }
}