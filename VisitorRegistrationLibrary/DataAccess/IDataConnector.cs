using System;
using System.Collections.Generic;
using VisitorRegistrationLibrary.Models;

namespace VisitorRegistrationLibrary.DataAccess
{
    public interface IDataConnector
    {
        public void CreateCompany(CompanyModel model);
        public List<CompanyModel> GetAllCompanies(); 

    }
}
