using System;
using VisitorRegistrationLibrary.Models;
using VisitorRegistrationLibrary.DataAccess;

namespace VisitorRegistrationConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompanyModel model = new CompanyModel();
            //model.Name = "AllPhi";

            var sqlConn = new MySqlConnector();
            var companyList = sqlConn.GetAllCompanies();


            Console.WriteLine("Companies:");
            foreach (var company in companyList)
            {
                Console.WriteLine($"Id: {company.Id}, Name: {company.Name}");
            }

            Console.ReadLine();


        }
    }
}
