using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VisitorRegistration.BL.Components;
using VisitorRegistration.BL.Requests;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;
using VisitorRegistration.Mvc.Models;

namespace VisitorRegistration.Mvc.Controllers
{
    public class CheckInController : Controller
    {
        private readonly ILogger<CheckInController> _logger;
        private readonly IVisitorDataAccess _visitorDataAccess;
        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly IMapper _mapper;
        private readonly RegistrationComponent _registrationComponent;

        public CheckInController(
            ILogger<CheckInController> logger,
            IVisitorDataAccess visitorDataAccess,
            ICompanyDataAccess companyDataAccess,
            IEmployeeDataAccess employeeDataAccess,
            RegistrationComponent registrationComponent,
            IMapper mapper)
        {
            _logger = logger;
            _visitorDataAccess = visitorDataAccess;
            _companyDataAccess = companyDataAccess;
            _employeeDataAccess = employeeDataAccess;
            _registrationComponent = registrationComponent;
            _mapper = mapper;
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
            if (visitor == null)
            {
                return View("NewVisitor", new VisitorViewModel() {Email = email});
            }
           
            var visitorViewModel = _mapper.Map<VisitorViewModel>(visitor);
            SetVisitorSessionData(visitorViewModel.Id, visitorViewModel.Email, visitorViewModel.Firstname);
            var companyListViewModel = new CompanyListViewModel(_companyDataAccess, _mapper);

            return View("CompanySelection", companyListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveNewVisitor(VisitorViewModel visitorViewModel)
        {
            if (!ModelState.IsValid) return View("NewVisitor",visitorViewModel);

            var body = HttpContext.Request.Body;
            var visitor = await _visitorDataAccess.Add(_mapper.Map<Visitor>(visitorViewModel));
            SetVisitorSessionData(visitorViewModel.Id, visitorViewModel.Email, visitorViewModel.Firstname);
            var companyListViewModel = new CompanyListViewModel(_companyDataAccess, _mapper);
          
            return View("CompanySelection", companyListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompanySelected(int companyId)
        {
            if (companyId == 0) return View("Error", new ErrorViewModel { });

            HttpContext.Session.SetInt32("company_id", companyId);
            var employeeListViewModel = new EmployeeListViewModel(companyId, _employeeDataAccess, _mapper);

            return View("EmployeeSelection", employeeListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployeeSelected(int employeeId)
        {
            if (employeeId == 0) return View("Error", new ErrorViewModel { });

            var response = _registrationComponent.CheckIn(
                new CheckInRequest
                {
                    CompanyId = HttpContext.Session.GetInt32("company_id").Value,
                    EmployeeId = employeeId,
                    VisitorId = HttpContext.Session.GetInt32("visitor_id").Value
                });

            HttpContext.Session.Clear();
            if (response.Successful) return View("CheckInCompleted");

            return View("CheckInFailed", response);            
        }

        private void SetVisitorSessionData(int id, string email, string firstname)
        {
            HttpContext.Session.SetInt32("visitor_id", id);
            HttpContext.Session.SetString("visitor_email", email);
            HttpContext.Session.SetString("visitor_firstname", firstname);
        }
    }
}
