using System.ComponentModel.DataAnnotations;

namespace VisitorRegistration.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(256, MinimumLength = 2), EmailAddress]
        public string Email { get; set; }

    }
}
