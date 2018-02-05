using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AngularJSCRUD.Models
{
    public class EmployeeDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddEmployee(EmployeeModel empmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", empmodel.FullName);
            cmd.Parameters.AddWithValue("@JobPostion", empmodel.JobPostion);
            cmd.Parameters.AddWithValue("@Address", empmodel.Address);
            cmd.Parameters.AddWithValue("@Username", empmodel.Username);
            cmd.Parameters.AddWithValue("@Password", empmodel.Password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<EmployeeModel> GetEmployee()
        {
            connection();
            List<EmployeeModel> employeelist = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                employeelist.Add(
                    new EmployeeModel
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        FullName = Convert.ToString(dr["FullName"]),
                        JobPostion = Convert.ToString(dr["JobPostion"]),
                        Address = Convert.ToString(dr["Address"]),
                        Username = Convert.ToString(dr["Username"]),
                        Password = Convert.ToString(dr["Password"])
                    });
            }
            return employeelist;
        }
        
        public bool UpdateDetails(EmployeeModel empmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", empmodel.EmpId);
            cmd.Parameters.AddWithValue("@FullName", empmodel.FullName);
            cmd.Parameters.AddWithValue("@JobPostion", empmodel.JobPostion);
            cmd.Parameters.AddWithValue("@Address", empmodel.Address);
            cmd.Parameters.AddWithValue("@Username", empmodel.Username);
            cmd.Parameters.AddWithValue("@Password", empmodel.Password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteEmployee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", id);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}