using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using Thales.BusinessLayer.BO;
using Thales.CommonInterfaces.DTO;
using Thales.DataAccessLayer;

namespace Thales.BusinessLayer
{
    public class EmployeeOperationsBL
    {
        private RequestByAPI requestByAPI;
        public EmployeeOperationsBL()
        {
            requestByAPI = new RequestByAPI();
        }
        private void CalculateAnnualSalaryByEmployee(List<IEmployee_DTO> lista)
        {
            foreach (Employee_BO employee in lista)
            {
                employee.employee_anual_salary = employee.employee_salary * 12;
            }
        }
        private void CalculateAnnualSalaryByEmployee(Employee_BO employee)
        {
                employee.employee_anual_salary = employee.employee_salary * 12;
        }

        public List<IEmployee_DTO> ObtainListEmployees(string routeConsultApi, out string msjResult)
        {
            List<IEmployee_DTO> lista;
            RestResponse result= requestByAPI.RunPetition(routeConsultApi, Method.Get);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DataComplete_BO data = JsonConvert.DeserializeObject<DataComplete_BO>(result.Content);
                msjResult = data.message;
                lista = new List<IEmployee_DTO>();
                lista.AddRange(data.data);
                CalculateAnnualSalaryByEmployee(lista);
            }
            else
            {
                msjResult = result.ErrorMessage;
                lista = null;
            }
            return lista;
        }

        public Employee_BO ObtainDataEmployee(string routeConsultApi, out string msjResult)
        {
            Employee_BO employee;
            RestResponse result = requestByAPI.RunPetition(routeConsultApi, Method.Get);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DataSingle_BO data = JsonConvert.DeserializeObject<DataSingle_BO>(result.Content);
                msjResult = data.message;
                employee = new Employee_BO();
                CalculateAnnualSalaryByEmployee(employee);
            }
            else
            {
                msjResult = result.ErrorMessage;
                employee = null;
            }
            return employee;
        }

    }
}
