using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thales.CommonInterfaces.DTO;

namespace Thales.Principal.Models
{
    public class Employee : IEmployee_DTO
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
        public long employee_anual_salary { get; set; }
    }
}