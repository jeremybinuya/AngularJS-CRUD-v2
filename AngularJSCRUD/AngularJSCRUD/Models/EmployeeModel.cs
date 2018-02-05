using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AngularJSCRUD.Models
{
    public class EmployeeModel
    {

        public int EmpId { get; set; }
        public string FullName { get; set; }
        public string JobPostion { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}