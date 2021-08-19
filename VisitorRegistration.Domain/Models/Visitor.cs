using System.Collections.Generic;

namespace VisitorRegistration.Domain.Models
{
    public class Visitor : Person
    {
        public ICollection<Registration> Registrations { get; set; }
        
    }
}
