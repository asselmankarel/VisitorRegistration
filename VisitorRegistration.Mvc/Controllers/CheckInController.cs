using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;
using VisitorRegistration.Mvc.Models;

namespace VisitorRegistration.Mvc.Controllers
{
    public class CheckInController : Controller
    {
        private ILogger<CheckInController> _logger;
        private IVisitorDataAccess _visitorDataAccess;
        private readonly IMapper _mapper;
        private readonly ISession _session;

        public CheckInController(
            ILogger<CheckInController> logger,
            IVisitorDataAccess visitorDataAccess,
            IMapper mapper,
            ISession session)
        {
            _logger = logger;
            _visitorDataAccess = visitorDataAccess;
            _mapper = mapper;
            _session = session;
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
            _session.Set("user_id", visitorViewModel);
            return View("CompanySelection", visitorViewModel);
        }
    }
}
