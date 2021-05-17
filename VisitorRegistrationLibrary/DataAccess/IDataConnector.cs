using System;
using System.Collections.Generic;
using VisitorRegistrationLibrary.Models;

namespace VisitorRegistrationLibrary.DataAccess
{
    public interface IDataConnector
    {
        public void CreateCompany(CompanyModel model);
        // public List<CompanyModel> GetAllCompanies();
        public List<CompanyModel> GetCompany_All();
        public List<EmployeeModel> GetEmployeesByCompanyId(int companyId);

    }
}
