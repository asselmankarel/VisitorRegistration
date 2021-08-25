using AutoMapper;
using System.Collections.Generic;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.Mvc.Models
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
        public int EmployeeId { get; set; }

        public EmployeeListViewModel(int? companyId, IEmployeeDataAccess employeeDataAccess, IMapper mapper)
        {
            var employees = new List<Employee>();
            if (companyId.HasValue)
            {
                employees = employeeDataAccess.GetByCompanyId(companyId.Value).Result;
            }
            else 
            {
                employees = employeeDataAccess.GetAll().Result;
            }

            foreach (var employee in employees)
            {
                Employees.Add(mapper.Map<EmployeeViewModel>(employee));
            }
        }
    }
}
