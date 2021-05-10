using System;
namespace VisitorRegistrationLibrary.Models
{
    public class EmployeeModel : PersonModel
    {
        public CompanyModel Company { get; set; }

        public EmployeeModel()
        {
        }

        public EmployeeModel(string firstName, string lastName, string emailAddress, CompanyModel company)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Company = company;

        }
        
    }
}
