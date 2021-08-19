using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.BL.Requests
{
    public class CheckInRequest
    {
        public Visitor Visitor { get; init; }

        public Company Company { get; init; }

        public Employee Employee { get; init; }
    }
}
