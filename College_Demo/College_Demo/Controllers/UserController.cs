using College_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Demo.Controllers
{
    [Authorization]
    public class UserController : Controller
    {
        College_DBContext db = new College_DBContext();
        public ActionResult Index()
        {
            return View();
        }

       // [AllowAnonymous]
        public ActionResult managestudents()
        {
            //select top(5) * from tbl_users where role = 'student'
            var list_of_students = db.tbl_user.Where(p => p.role == Role.Student).OrderBy(p => p.id).Take(5).ToList();
            return View(list_of_students);
        }

        public ActionResult deleteuser(int id)
        {
            var userToDelete = db.tbl_user.Find(id);
            db.tbl_user.Remove(userToDelete);

            db.SaveChanges();
            TempData["msg"] = "User Deleted Successfully!";
            return RedirectToAction("managestudents", "user");
        }

        public ActionResult edituser(int id)
        {
            var userToEdit = db.tbl_user.Find(id);
            return View(userToEdit);
        }

        [HttpPost]
        public ActionResult updateuser(User record)
        {
            db.tbl_user.Attach(record);
            db.Entry<User>(record).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            TempData["msg"] = "User Updated Successfully!";
            return RedirectToAction("managestudents", "user");
        }

        public JsonResult getmorerecords(int pageindex, int pagesize)
        {
            var students_list = db.tbl_user.Where(p => p.role == Role.Student).OrderBy(p => p.id).Skip(pageindex * pagesize).Take(pagesize).ToList();

            return Json(new { data = students_list }, JsonRequestBehavior.AllowGet);
        }
    }
}