using System.ComponentModel.DataAnnotations;

namespace VisitorRegistration.Mvc.Models
{
    public class VisitorViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(256, MinimumLength = 2)]
        public string Firstname { get; set; }

        [Required, StringLength(256, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
