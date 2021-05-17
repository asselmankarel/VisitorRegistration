using System;
using VisitorRegistrationLibrary.Models;
using System.Collections.Generic;

namespace VisitorRegistrationLibrary.DataAccess
{
    public class CsvConnector : IDataConnector
    {
        private string FilePath = "";

        public CsvConnector()
        {

        }

        public CsvConnector(string filePath)
        {
            FilePath = filePath;
        }


        public void CreateCompany(CompanyModel model)
        {
            List<CompanyModel> Companies = new List<CompanyModel>();
            // get Companies from CsvFile
            CsvConnectorProcessor.LoadCompanies($"{FilePath}/companies.csv");

            // get last used Id
            //int id = Companies;


            // set Id on new model

            // save to Csv file
                        
            throw new NotImplementedException();
        }

        public List<CompanyModel> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public List<CompanyModel> GetCompany_All()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetEmployeesByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
