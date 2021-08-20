using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VisitorRegistration.Mvc.Controllers
{
    public class CheckInController : Controller
    {
        private ILogger<CheckInController> _logger;

        public CheckInController(ILogger<CheckInController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Visitor()
        {
            var email = HttpContext.Request.Form["Email"].FirstOrDefault()?.ToLower();
            //check if visitor is known if not create new visitor

            return View();
        }
    }
}
