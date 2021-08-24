using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IMapper _mapper;
 
        public CheckInController(
            ILogger<CheckInController> logger,
            IVisitorDataAccess visitorDataAccess,
            ICompanyDataAccess companyDataAccess,
            IMapper mapper)
        {
            _logger = logger;
            _visitorDataAccess = visitorDataAccess;
            _companyDataAccess = companyDataAccess;
            _mapper = mapper;            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Visitor()
        {
            var email = HttpContext.Request.Form["Email"].FirstOrDefault()?.ToLower();
            var visitor = await _visitorDataAccess.GetByEmail(email);
            if (visitor == null)
            {
                return View("NewVisitor", new VisitorViewModel() {Email = email});
            }

            var visitorViewModel = _mapper.Map<VisitorViewModel>(visitor);
            HttpContext.Session.SetInt32("user_id", visitorViewModel.Id);
            HttpContext.Session.SetString("user_email", visitorViewModel.Email);
            HttpContext.Session.SetString("user_firstname", visitorViewModel.Firstname);

            return View("CompanySelection", visitorViewModel);
        }


        [HttpPost]
        public IActionResult SaveNewVisitor(VisitorViewModel visitorViewModel)
        {
            
            var request = visitorViewModel;

            var companyListViewModel = new CompanyListViewModel(_companyDataAccess, _mapper);
          
            return View("CompanySelection", companyListViewModel);
        }
    }
}
