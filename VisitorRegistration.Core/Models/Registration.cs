using System;

namespace VisitorRegistration.Core.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public Visitor Visitor { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartOfVisit { get; set; }
        public DateTime EndOfVisit { get; set; }
    }
}
