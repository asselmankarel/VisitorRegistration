using System;
namespace VisitorRegistrationLibrary.Models
{
    public class VisitorModel : PersonModel
    {
        public VisitorModel()
        {
        }

        public VisitorModel(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
