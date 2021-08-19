using System;

namespace VisitorRegistration.Domain.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public Visitor Visitor { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartOfVisit { get; set; } = DateTime.Now;
        public DateTime? EndOfVisit { get; set; } = null;
    }
}
