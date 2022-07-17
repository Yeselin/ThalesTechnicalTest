using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thales.CommonInterfaces.DTO
{
    public interface IEmployee_DTO
    {
        int id { get; set; }
        string employee_name { get; set; }
        int employee_salary { get; set; }
        int employee_age { get; set; }
        string profile_image { get; set; }
        long employee_anual_salary { get; set; }
    }
}
