using CrudMVCDBFirst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCDBFirst.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        tomEntities dbobj = new tomEntities();
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Studetns(tbl_Students model)
        {

            tbl_Students obj = new tbl_Students();
            obj.Name = model.Name;
            obj.Fname = model.Fname;
            obj.Email = model.Email;
            obj.Description = model.Description;

            dbobj.tbl_Students.Add(obj);
            dbobj.SaveChanges();
            return View("Student");
        }

    }
}