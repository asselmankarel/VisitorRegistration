using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.BL.Requests
{
    public class CheckOutRequest
    {
        public Visitor Visitor { get; init; }
    }
}
