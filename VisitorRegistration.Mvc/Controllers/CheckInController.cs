using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        public async Task<IActionResult> SaveNewVisitor(VisitorViewModel visitorViewModel)
        {
            if (!ModelState.IsValid) return View("NewVisitor",visitorViewModel);

            var body = HttpContext.Request.Body;
            var visitor = await _visitorDataAccess.Add(_mapper.Map<Visitor>(visitorViewModel));
            SetVisitorSessionData(visitorViewModel.Id, visitorViewModel.Email, visitorViewModel.Firstname);
            var companyListViewModel = new CompanyListViewModel(_companyDataAccess, _mapper);
          
            return View("CompanySelection", companyListViewModel);
        }



        private void SetVisitorSessionData(int id, string email, string firstname)
        {
            HttpContext.Session.SetInt32("user_id", id);
            HttpContext.Session.SetString("user_email", email);
            HttpContext.Session.SetString("user_firstname", firstname);
        }
    }
}
