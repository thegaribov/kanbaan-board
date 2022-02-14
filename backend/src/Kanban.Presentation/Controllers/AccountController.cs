using Microsoft.AspNetCore.Mvc;

namespace Kanban.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
