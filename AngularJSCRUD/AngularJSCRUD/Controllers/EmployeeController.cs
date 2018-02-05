using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using AngularJSCRUD.Models;

namespace AngularJSCRUD.Controllers
{
    public class EmployeeController : Controller
    {

        private EmployeeDBHandle db = new EmployeeDBHandle();
        // GET: Employee
        public ActionResult Index()
        {
            return Json(db.GetEmployee().ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeModel employee = db.GetEmployee().Find(x => x.EmpId == id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

       // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            db.AddEmployee(employee);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            db.UpdateDetails(employee);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeModel employee = db.GetEmployee().Find(x => x.EmpId == id);
            db.DeleteEmployee(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}
