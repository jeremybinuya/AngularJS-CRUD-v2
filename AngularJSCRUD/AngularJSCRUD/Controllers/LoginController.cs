using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJSCRUD.Models;

namespace AngularJSCRUD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private EmployeeDBHandle db = new EmployeeDBHandle();

        [HttpPost]
        public ActionResult LoginUser(EmployeeModel obj)
        {
            var user = db.GetEmployee().Where(x => x.Username.Equals(obj.Username) && x.Password.Equals(obj.Password)).SingleOrDefault();
            return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
    }
}