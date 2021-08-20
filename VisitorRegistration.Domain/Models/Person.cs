using System.ComponentModel.DataAnnotations;

namespace VisitorRegistration.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        private string _email;
        [StringLength(256, MinimumLength = 2), EmailAddress]
        public string Email
        {
            get => _email;
            set => _email = value?.ToLower();
        }

    }
}
