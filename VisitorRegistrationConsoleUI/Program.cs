using System;
using VisitorRegistrationLibrary.Models;
using VisitorRegistrationLibrary.DataAccess;
using VisitorRegistrationLibrary;

namespace VisitorRegistrationConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompanyModel model = new CompanyModel();
            //model.Name = "AllPhi";

            var conn = GlobalConfig.Connection();
            var companyList = conn.GetCompany_All();


            Console.WriteLine("Companies:");
            foreach (var company in companyList)
            {
                Console.WriteLine($"Id: {company.Id}, Name: {company.Name}");
            }


            //var types = model.GetType().GetProperties();
            Console.ReadLine();

        }
    }
}
