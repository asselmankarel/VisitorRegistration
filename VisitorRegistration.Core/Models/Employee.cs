using System.Collections.Generic;

namespace VisitorRegistration.Core.Models
{
    public class Employee : Person
    {
        public Company Company { get; set; }
        public ICollection<Registration> Registrations { get; set; }


    }
}
