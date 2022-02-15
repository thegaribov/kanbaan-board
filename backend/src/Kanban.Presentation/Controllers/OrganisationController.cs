using Microsoft.AspNetCore.Mvc;

namespace Kanban.Presentation.Controllers
{

    public class OrganisationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
