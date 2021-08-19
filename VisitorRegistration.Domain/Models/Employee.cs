using System.Collections.Generic;

namespace VisitorRegistration.Domain.Models
{
    public class Employee : Person
    {
        public Company Company { get; set; }
        public ICollection<Registration> Registrations { get; set; }


    }
}
