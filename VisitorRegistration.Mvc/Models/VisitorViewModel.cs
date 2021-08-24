using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorRegistration.Mvc.Models
{
    public class VisitorViewModel
    {
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string Firstname { get; set; }

        [StringLength(256, MinimumLength = 2)]
        public string Lastname { get; set; }

        [StringLength(256, MinimumLength = 2), EmailAddress]
        public string Email { get; set; }
    }
}
