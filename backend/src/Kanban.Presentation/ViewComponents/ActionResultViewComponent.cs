using Kanban.Core.Helpers.ActionResult;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Kanban.Presentation.ViewComponents
{
    public class ActionResultMessageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actionResultMessage = TempData["Message"] != null 
                ? JsonConvert.DeserializeObject<ActionResultMessage>(TempData["Message"].ToString()) 
                : null;

            return View("ActionResultMessage", actionResultMessage);
        }
    }
}
