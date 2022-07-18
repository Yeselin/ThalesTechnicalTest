using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thales.BusinessLayer;
using Thales.CommonInterfaces.DTO;
using Thales.Principal.Models;

namespace Thales.Principal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeOperationsBL operationBL;
        string messageResult;
        public EmployeeController()
        {
            operationBL = new EmployeeOperationsBL();
        }
        // GET: Employee
        public ActionResult Index()
        {

            IEnumerable<Employee> datos = (IEnumerable<Employee>)ConsultAllEmployees();
            return View(datos);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(ConsultOneEmployee(id));
        }
        [NonAction]
        public List<IEmployee_DTO> ConsultAllEmployees()
        {
            List<IEmployee_DTO> listEmployees = new List<IEmployee_DTO>();
            string routeConsult = ConfigurationManager.AppSettings["BaseEndPoint"].ToString() + "employees";
            listEmployees = operationBL.ObtainListEmployees(routeConsult, out messageResult);
            return listEmployees;
        }

        [NonAction]
        public Employee ConsultOneEmployee(int id)
        {
            Employee employee = new Employee();
            string routeConsult = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["BaseEndPoint"].ToString(), "employee", id.ToString());
            employee = (Employee)(IEmployee_DTO)operationBL.ObtainDataEmployee(routeConsult, out messageResult);
            return employee;
        }

    }
}
