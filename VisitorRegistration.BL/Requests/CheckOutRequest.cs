using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.BL.Requests
{
    public class CheckOutRequest
    {
        public Visitor Visitor { get; init; }
    }
}
