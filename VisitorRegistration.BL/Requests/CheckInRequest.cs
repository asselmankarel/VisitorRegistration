using System;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.BL.Requests
{
    public class CheckInRequest
    {
        public int VisitorId { get; init; }

        public int CompanyId { get; init; }

        public int EmployeeId { get; init; }

        public DateTime StartOfVisit { get; init; } = DateTime.Now;
    }
}
