using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorRegistration.BL.Components;
using VisitorRegistration.BL.Requests;
using VisitorRegistration.DataAccess.Services;

namespace VisitorRegistration.Mvc.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ILogger<CheckInController> _logger;
        private readonly IVisitorDataAccess _visitorDataAccess;
        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly IMapper _mapper;
        private readonly RegistrationComponent _registrationComponent;

        public CheckOutController(
            ILogger<CheckInController> logger,
            IVisitorDataAccess visitorDataAccess,
            ICompanyDataAccess companyDataAccess,
            IEmployeeDataAccess employeeDataAccess,
            IMapper mapper, RegistrationComponent registrationComponent)
        {
            _logger = logger;
            _visitorDataAccess = visitorDataAccess;
            _companyDataAccess = companyDataAccess;
            _employeeDataAccess = employeeDataAccess;
            _mapper = mapper;
            _registrationComponent = registrationComponent;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Visitor(string email)
        {
            var visitor = await _visitorDataAccess.GetByEmail(email);
            if (visitor == null) return View("EmailNotFound", email);

            var response = await _registrationComponent.CheckOut(new CheckOutRequest { Visitor = visitor });
            if (response.Successful) return View("CheckOutOk");
            
            return View("CheckOutNotOk", response);
        }
    }
}
