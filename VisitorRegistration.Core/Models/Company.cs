using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisitorRegistration.Core.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
