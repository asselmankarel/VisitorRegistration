using System.Collections.Generic;

namespace VisitorRegistration.Core.Models
{
    public class Visitor : Person
    {
        public ICollection<Registration> Registrations { get; set; }

    }
}
