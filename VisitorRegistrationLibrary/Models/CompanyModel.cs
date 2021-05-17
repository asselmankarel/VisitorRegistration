using System;
using System.Collections.Generic;

namespace VisitorRegistrationLibrary.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeModel> Employees { get; set; }

        public CompanyModel()
        {
        }
    }
}
